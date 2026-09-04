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
becomes a diagnostic.

1. Normalise: strip a UTF-8 BOM, normalise CRLF to LF, trim leading and trailing whitespace.
   Eddy's `x12Document.Parse` reads the ISA from the first 106 characters, so leading whitespace
   breaks it.
2. Detect the format from the first three characters: `ISA` is X12, `UNA` or `UNB` is EDIFACT,
   anything else is Unknown. Phase 0 parses X12 only. EDIFACT and Unknown produce a document with
   raw lines, no tree, and one Info diagnostic saying the format is not supported yet.
3. Raw lines. The segment terminator is the character at index 105 of the ISA (the one after the
   component separator). Split the text on it, trim each piece, drop blanks, and number the rest
   from 1. This matches how `x12Document.Parse` numbers `ValidationResult.LineNumber`: it counts
   non-blank segments from 1 starting at ISA. Verify this with a test that plants a known error on a
   known line.
4. Parse with `x12Document.Parse`. Catch `InvalidFileFormatException`, `KeyNotFoundException`
   (unknown segment code for that version) and any other exception. Each becomes an Error
   diagnostic with the best line number you can determine, and the document keeps its raw lines.
5. Tree. One Interchange node (ISA, subtitle: control number, sender -> receiver, date), one
   FunctionalGroup node (GS, subtitle: functional id, sender -> receiver, version), one
   TransactionSet node per `Section` (title: "ST 204", subtitle: control number and segment count),
   and one Segment node per segment in `Section.Segments`. Node.Model is the Eddy object. Segment
   titles are "N1 Name" derived from the model type name `N1_Name`; subtitles are the first two or
   three element values joined with a space.
6. Line numbers. Walk the raw lines in order alongside the parsed structure: line 1 is ISA, 2 is
   GS, then for each section the ST line, its segments, and the SE line, then GE and IEA. Set
   Node.LineNumber and RawLine.Node for each pair. Do not assume the ST/SE lines are in
   `Section.Segments`; they are not.
7. Elements. Reflect over public properties with `[Position]` (Eddy.Core.Attributes.PositionAttribute),
   ordered by position. Reference is code + two-digit position ("N101"). Name is the property name
   split on capitals ("EntityIdentifierCode" -> "Entity Identifier Code"), with trailing digits kept
   ("EntityIdentifierCode2" -> "Entity Identifier Code 2"). Value is the property value as string.
   A property whose type derives from `EdiX12Component` is a composite: recurse into it for
   Components and set Value to the composite's raw text if available, else the joined component
   values. Include absent elements so the grid shows the whole segment definition.
   ISA and GS headers have no `[Position]` attributes; list all their public string/int properties
   in declaration order instead.
8. Diagnostics. Each `ValidationResult` in `document.ValidationErrors` becomes one
   DiagnosticViewModel per `Error`, severity Error, with the result's LineNumber, the segment code
   from the raw line at that number, and `error.ToString()` as the message. Attach it to the node at
   that line and mark the raw line. Element HasError: mark an element when the message contains its
   PropertyName.
9. Summary and Format: "X12 004010" style, and the Summary string described in DocumentViewModel.

Selection sync lives in `ViewModels/DocumentViewModel.Selection.cs` (a partial class): implement
`OnSelectedNodeChanged` and `OnSelectedRawLineChanged` so each updates the other without
re-entering, and raise `SelectedElements` changed.

## Sample files

Three cleaned X12 004010 files sit in Samples/. They have fixed-width ISA lines and correct SE, GE
and IEA trailers. 204 and 210 use newline as the segment terminator; 214 uses `~` with a newline
after it for readability, which Eddy handles because it trims each piece.
