# Eddy Notepad

A cross-platform EDI viewer built on the Eddy parsing libraries. It is the Phase 0 app from the
Eddy Notepad roadmap: open an X12 file, see it as an envelope tree, inspect any segment element by
element, and read the validation problems Eddy finds.

    dotnet run --project Eddy.Notepad            # opens the window
    dotnet run --project Eddy.Notepad -- file.edi
    dotnet test Eddy.Notepad.Tests

## Layout

    Eddy.Notepad/
      Program.cs, App.axaml         Avalonia bootstrap. App wires MainWindow to MainWindowViewModel.
      Views/                        XAML and code-behind only. No parsing logic here.
      ViewModels/                   Plain observable state. No Avalonia types here.
      Services/                     DocumentLoader (parse -> view models), IFilePicker, SampleDocuments.
      Samples/*.edi                 Embedded sample files, listed under File > Open Sample.
    Eddy.Notepad.Tests/             xunit tests for Services and ViewModels. Runs headless.

Dependencies: Avalonia 11.3 with the Fluent theme, CommunityToolkit.Mvvm 8.4 (use `[ObservableProperty]`
and `[RelayCommand]`), Eddy.Core and Eddy.x12. Do not add Eddy.x12.DomainModels.* references in this
phase; they slow the build a lot and Phase 0 does not need loop mapping.

## The screen

Modelled on Liaison EDI Notepad. One window, one document per tab.

    +--------------------------------------------------------------------------------+
    | File   View   Help                                                             |
    +--------------------------------------------------------------------------------+
    | [Sample-204-LoadTender] [x]  [orders.edi] [x]                                  |
    +------------------------------+-------------------------------------------------+
    | Tree                         | Elements of selected node                       |
    |  v ISA 000003438             |  Ref    Name                       Value        |
    |    v GS SM 4405197800 -> ... |  N101   Entity Identifier Code     PF           |
    |      v ST 204 0001           |  N102   Name                       XYZ CORP     |
    |          B2  ...             |  N103   Identification Code Qual.  9            |
    |          N1  PF XYZ CORP     |  N104   Identification Code        9995555500000|
    |          N3  31875 SOLON RD  +-------------------------------------------------+
    |          ...                 | Raw segments                                    |
    |                              |   7  N1*PF*XYZ CORP*9*9995555500000             |
    |                              |   8  N3*31875 SOLON RD                          |
    +------------------------------+-------------------------------------------------+
    | Diagnostics (2 errors)                                                         |
    |  ! Line 12  N7   EquipmentDescriptionCode is required                          |
    +--------------------------------------------------------------------------------+
    | Status: X12 004010 · 1 interchange · 1 group · 1 transaction set · 2 errors   |
    +--------------------------------------------------------------------------------+

Behaviour:

- Selecting a tree node selects the matching raw line and fills the element grid. Selecting a raw
  line selects its tree node. Double-clicking a diagnostic selects its node.
- Rows with errors are tinted in the tree, raw view and grid. Envelope nodes show a count badge.
- Drag and drop a file onto the window to open it. Ctrl+O opens the picker. Ctrl+W closes the tab.
- The raw view is monospace, read-only, with a line number gutter.

## View model contract

Views bind only to these types. The loader fills them. Keep property names stable; both the views
task and the core task were written against this list.

    MainWindowViewModel
      Documents, ActiveDocument, StatusText, SampleNames, HasDocuments
      OpenFileCommand, OpenSampleCommand(string), CloseDocumentCommand(DocumentViewModel)
      OpenPathAsync(path), OpenText(text, displayName, filePath)

    DocumentViewModel
      DisplayName, FilePath, Format, RawText, RawLines, Nodes, Diagnostics
      ErrorCount, WarningCount, IsValid, Summary
      SelectedNode, SelectedRawLine, SelectedElements

    DocumentNodeViewModel   Kind, Code, Title, Subtitle, LineNumber, Model, Children, Elements,
                            Diagnostics, ErrorCount, HasErrors, IsExpanded, IsSelected
    ElementViewModel        Reference, Position, Name, PropertyName, Value, HasValue, IsComposite,
                            Components, HasError
    RawLineViewModel        LineNumber, Text, Node, HasError
    DiagnosticViewModel     Severity, LineNumber, SegmentCode, Message, Node, Location

## Loader contract

`DocumentLoader.Load(text, displayName, filePath)` must never throw. Everything Eddy cannot handle
becomes a diagnostic. It parses with `x12Document.Parse(text, new x12ParseOptions { Lenient = true })`,
which itself never throws for content problems (a bad file still produces a `ValidationResult`, not an
exception) -- the loader keeps only one outer catch-all, as a last resort for something unanticipated.

1. Normalise: strip a UTF-8 BOM, normalise CRLF to LF, trim leading and trailing whitespace. (The
   parser tolerates leading whitespace itself now, but the loader still needs clean text to detect
   the format from the first three characters and, if parsing fails outright, to fall back to a plain
   split.)
2. Detect the format from the first three characters: `ISA` is X12, `UNA` or `UNB` is EDIFACT,
   anything else is Unknown. Phase 0 parses X12 only. EDIFACT and Unknown produce a document with
   raw lines, no tree, and one Info diagnostic saying the format is not supported yet.
3. Raw lines come from the parser's `Source` spans (`Eddy.Core.SegmentSource`, via `ISourceTracked`),
   not from re-splitting the text: collect every parsed object that carries a `Source` -- the ISA
   header, every GS header, every ST header, every segment (including `Unknown_Segment` instances),
   every SE/GE/IEA trailer, every orphan segment -- across all of `document.Interchanges`, order them
   by `Source.LineNumber`, and build one `RawLineViewModel` per span with `Text = Source.RawText`.
   This is exactly the convention `ValidationResult.LineNumber` uses (non-blank segments, numbered
   from 1 starting at ISA), so `RawLineViewModel.LineNumber` still matches it. When the parser stopped
   early -- an invalid ISA in lenient mode leaves `Interchanges` empty or, in a multi-interchange file,
   partial -- there are no spans for the rest of the file, so fall back to the old newline/terminator
   split so the raw view still shows the whole file.
4. Tree, built directly from `document.Interchanges`: one Interchange node per `x12Interchange`
   (Model = its Header), one FunctionalGroup node per `x12FunctionalGroup` (a group whose Header is
   null -- a missing GS, recorded only in lenient mode -- gets the title "GS (missing)" and a subtitle
   saying so), one TransactionSet node per `Section` (Model = the Section, Elements from the ST
   header, title "ST 204", subtitle control number and segment count), and one Segment node per
   segment in `Section.Segments`. `Interchange.OrphanSegments` and `FunctionalGroup.OrphanSegments`
   (segments the parser found outside any transaction set, or outside any group) become Segment nodes
   under their container, placed by line number among their siblings, with their subtitle prefixed
   "(outside any transaction set) ". `Unknown_Segment` instances (an unrecognised segment code, lenient
   mode only) become Segment nodes titled "{SegmentId} Unknown segment" with elements built from their
   `Elements` list. SE/GE/IEA trailers never get their own node: instead their line number is mapped to
   the node they close (transaction set, group, or interchange), so a diagnostic on a trailer line lands
   on that node, not nowhere.
5. Elements. Reflect over public properties with `[Position]` (Eddy.Core.Attributes.PositionAttribute),
   ordered by position. Reference is code + two-digit position ("N101"). Name is the property name
   split on capitals ("EntityIdentifierCode" -> "Entity Identifier Code"), with trailing digits kept
   ("EntityIdentifierCode2" -> "Entity Identifier Code 2"). Value is the property value as string.
   A property whose type derives from `EdiX12Component` is a composite: recurse into it for
   Components and set Value to the composite's raw text if available, else the joined component
   values. Include absent elements so the grid shows the whole segment definition.
   The ISA header has no `[Position]` attributes; list all its public string/int properties in
   declaration order instead. (GS headers gained `[Position]` attributes with the hardened parser, so
   they go through the normal positioned path now.)
6. Diagnostics. Each `ValidationResult` in `document.ValidationErrors` becomes one DiagnosticViewModel
   per `Error`, with the result's LineNumber, `result.SegmentCode` (falling back to the raw line's
   leading identifier only when that's null), and `error.ToString()` as the message. The node is the
   one whose line number matches (via the raw line -- see rule 4 for how trailer lines resolve to a
   container node). Severity is Warning for `ErrorCodes.MissingTrailer` and
   `ErrorCodes.SegmentOutsideTransactionSet`, Error for everything else (compare `ErrorCodes` by
   reference or by their `ErrorCode` number). Element HasError uses `Error.PropertyName` and
   `Error.ElementPosition` (set by `Eddy.Core.Validation.BasicValidator`) instead of a message-contains
   check: an element is in error when a diagnostic on its segment has PropertyName equal to the
   element's PropertyName, or ElementPosition equal to its Position.
7. Summary and Format handle several interchanges and groups: "X12 004010 · 2 interchanges · 3 groups
   · 5 transaction sets · 1 error". Format uses the first group's version when there is one, else
   plain "X12".

Selection sync lives in `ViewModels/DocumentViewModel.Selection.cs` (a partial class): implement
`OnSelectedNodeChanged` and `OnSelectedRawLineChanged` so each updates the other without
re-entering, and raise `SelectedElements` changed.

## Sample files

Three cleaned X12 004010 files sit in Samples/. They have fixed-width ISA lines and correct SE, GE
and IEA trailers. 204 and 210 use newline as the segment terminator; 214 uses `~` with a newline
after it for readability, which Eddy handles because it trims each piece.
