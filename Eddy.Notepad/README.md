# Eddy Notepad

A cross-platform EDI viewer and editor built on the Eddy parsing libraries. Open an X12 or EDIFACT
file, see it as an envelope tree, inspect any segment element by element, read the validation
problems Eddy finds -- and now edit element values in place, delete or insert segments, fix control
counts, save back to disk, and generate a 997 or 999 acknowledgment for an X12 document.

    dotnet run --project Eddy.Notepad            # opens the window
    dotnet run --project Eddy.Notepad -- file.edi
    dotnet test Eddy.Notepad.Tests

## Layout

    Eddy.Notepad/
      Program.cs, App.axaml.cs      Avalonia bootstrap. App loads metadata packs into MetadataCatalog.Default
                                     (Services/MetadataPacks.cs) before wiring MainWindow to MainWindowViewModel.
      Views/                        XAML and code-behind only. No parsing logic here.
      ViewModels/                   Plain observable state. No Avalonia types here.
      Services/                     DocumentLoader (parse -> view models), SegmentElementReader (segment/header
                                     model -> element grid rows, via MetadataCatalog.Describe), DocumentEditor
                                     (element/segment edits and control-count recalculation as text
                                     transformations -- see "Editing" below), MetadataPacks (loads the embedded +
                                     EDDY_METADATA_PACKS packs), IFilePicker, SampleDocuments.
                                     DocumentLoader is split across three files: DocumentLoader.cs holds
                                     the entry point and the pieces shared by both formats, and
                                     DocumentLoader.X12.cs / DocumentLoader.Edifact.cs hold the
                                     format-specific tree building. The two read alike by design -- same
                                     method names and shapes, one set of model types swapped for the other.
      Samples/*.edi                 Embedded sample files, listed under File > Open Sample.
    Eddy.Notepad.Tests/             xunit tests for Services and ViewModels. Runs headless.

Dependencies: Avalonia 11.3 with the Fluent theme, CommunityToolkit.Mvvm 8.4 (use `[ObservableProperty]`
and `[RelayCommand]`), Eddy.Core, Eddy.x12 and Eddy.Edifact. Do not add Eddy.x12.DomainModels.* or
Eddy.Edifact.DomainModels.* references beyond the one exception below; they slow the build a lot and
most of them add nothing Notepad needs. The one exception is
Eddy.x12.DomainModels.CommunicationsAndControls, referenced solely for
`Acknowledgments.FunctionalAcknowledgmentBuilder`/`ImplementationAcknowledgmentBuilder` (Tools > Generate
997/999; see "Acknowledgments" below).

## Metadata

Eddy.Core.Metadata (see the repository's docs/metadata-packs.md) supplies data element numbers, formal
types (ID/AN/N/R/DT/TM), requirement and code meanings on top of what the segment models know natively.
`DocumentLoader` takes a `MetadataCatalog` (a parameterless constructor uses `MetadataCatalog.Default`)
and hands it to `SegmentElementReader`, which replaces the old pure-reflection element builder: element
structure (references, names, positions, composites) now comes from `MetadataCatalog.Describe(Type)`,
overlaid with whatever packs are loaded; values still come from the model instance.

At startup, `Services/MetadataPacks.LoadDefaults` loads every metadata pack embedded in the application
(the three EDIFACT packs under `metadata/packs/`, embedded via the repository root's `metadata/packs/*.json`
in Eddy.Notepad.csproj), then every `*.json` file in the directory named by the `EDDY_METADATA_PACKS`
environment variable, into `MetadataCatalog.Default`. A user can add more at runtime through
File > Load Metadata Pack…, which loads the chosen file into the catalog and reparses every open document
so its element grid picks up the new data; Help > Loaded Metadata lists what is currently loaded.

## The screen

Modelled on Liaison EDI Notepad. One window, one document per tab.

    +---------------------------------------------------------------------------------------------+
    | File   View   Help                                                                          |
    +---------------------------------------------------------------------------------------------+
    | [Sample-204-LoadTender] [x]  [orders.edi] [x]                                               |
    +------------------------------+----------------------------------------------------------------+
    | Tree                         | Elements of selected node                                       |
    |  v ISA 000003438             |  Ref    Name       Value          DE    Type      Req  Meaning  |
    |    v GS SM 4405197800 -> ... |  N101   Entity Id.  PF            98    ID 2..3   M    Buyer     |
    |      v ST 204 0001           |  N102   Name         XYZ CORP     93    AN 1..60  C              |
    |          B2  ...             |  N103   Ident. Qual. 9            66    ID 1..2   C    D-U-N-S...|
    |          N1  PF XYZ CORP     |  N104   Ident. Code   9995555500000 67  AN 2..80  C              |
    |          N3  31875 SOLON RD  +----------------------------------------------------------------+
    |          ...                 | Raw segments                                                     |
    |                              |   7  N1*PF*XYZ CORP*9*9995555500000                              |
    |                              |   8  N3*31875 SOLON RD                                           |
    +------------------------------+----------------------------------------------------------------+
    | Diagnostics (2 errors)                                                                       |
    |  ! Line 12  N7   EquipmentDescriptionCode is required                                        |
    +---------------------------------------------------------------------------------------------+
    | Status: X12 004010 · 1 interchange · 1 group · 1 transaction set · 2 errors · 3 metadata packs|
    +---------------------------------------------------------------------------------------------+

An EDIFACT document renders the same way, with UNB/UNG/UNH nodes instead of ISA/GS/ST, "message"
instead of "transaction set" in the status line and Summary, and a UNH segment count instead of an
ST/SE one -- see "Loader contract" below.

The DE/Type/Req/Meaning columns above are illustrative: they only fill in once a metadata pack for the
element's standard and version is loaded (see "Metadata" above). X12 ships with no bundled pack, so a
freshly started Eddy Notepad shows those columns blank for X12 documents until the user loads one; the
three bundled EDIFACT packs (D96A, D01B, D07A) mean an EDIFACT document has them from the start.

Behaviour:

- Selecting a tree node selects the matching raw line and fills the element grid. Selecting a raw
  line selects its tree node. Double-clicking a diagnostic selects its node.
- Rows with errors are tinted in the tree, raw view and grid. Envelope nodes show a count badge.
- In the element grid, an Identifier-typed element whose value is not in a loaded code list shows
  "not in code list" in the Meaning column, in the warning colour -- this is informational, not a
  diagnostic (see "Metadata" above); a valid code with no description text shows "valid code", dimmed.
- Drag and drop a file onto the window to open it. Ctrl+O opens the picker. Ctrl+W closes the tab
  (asking to confirm first if it has unsaved changes).
- The raw view is monospace, read-only, with a line number gutter.
- File > Load Metadata Pack… adds one metadata pack file to the catalog and reparses every open
  document. Help > Loaded Metadata lists every pack currently loaded (name, standard, version, source).
- Editing, saving and acknowledgment generation: see the three sections below.

## Keyboard shortcuts

    Ctrl+O            File > Open…
    Ctrl+S            File > Save
    Ctrl+Shift+S      File > Save As…
    Ctrl+W            File > Close (confirms first if the tab is dirty)
    Ctrl+Z            Edit > Undo
    Ctrl+Y            Edit > Redo
    Delete            Edit > Delete Segment, when the tree has keyboard focus
    F2                Open the in-place editor for the focused element's value
    Double-click      Open the in-place editor for an element's value (Value column)
    Enter / Escape    Commit / cancel the in-place editor

## Editing

Every edit -- element value, segment delete, segment insert, control-count recalculation -- is a text
transformation, not a model mutation: the document keeps its text as the single source of truth. An
edit produces new document text (via `Eddy.Core.SourceEdit` or `x12Document`/`EdiFactDocument`
.RecalculateControlCounts), and that text is reloaded through the same `DocumentLoader` used to open
files, then swapped into `MainWindowViewModel.Documents` at the edited document's index -- same tab
position, active if it was, selection restored by matching `DocumentNodeViewModel.LineNumber`. Nothing
here regenerates a whole file from the in-memory model; a segment nobody touched keeps its exact bytes.

`Services/DocumentEditor.cs` holds the format-aware (X12 vs EDIFACT, keyed off
`DocumentViewModel.Format`), UI-free logic, so it is unit-testable on its own (see
Eddy.Notepad.Tests/DocumentEditorTests.cs):

    DocumentEditor
      ReplaceElementValue(document, node, element, newValue)         -> new document text
      RemoveSegment(document, node)                                  -> new document text
      InsertSegmentAfter(document, node, rawSegmentText)              -> new document text
      InsertSegmentBefore(document, node, rawSegmentText)             -> new document text
      RecalculateCounts(document)                                    -> ControlCountResult
      RecalculateCounts(text, format)  [static]                       -> ControlCountResult

`MainWindowViewModel.ApplyTextEdit(document, newText, description)` is the one place that reloads and
swaps a document; every command below ends by calling it (directly, or via Undo/Redo, which do the
mirror-image operation on their own stacks). `DocumentViewModel` carries the editing state:
`IsDirty`, `CanUndo`, `CanRedo`, `UndoStack`/`RedoStack` (plain text snapshots -- files are small, so a
snapshot-per-edit history is simplest), `SavedText` (the baseline `IsDirty` compares `RawText`
against: what was last opened or saved), and `TabTitle` (`DisplayName` with a trailing "•" while dirty,
what the tab strip actually binds to).

- **Element values.** In the element grid, double-click a Value cell (or focus it and press F2) to
  edit it in place; Enter commits, Escape cancels. On commit, `MainWindowViewModel.SetElementValue`
  calls `DocumentEditor.ReplaceElementValue`, which: sets the property on the underlying model
  (`DocumentNodeViewModel.Model` for a segment; for a component, the composite instance reached through
  the parent segment's property, creating it if absent; `Convert.ChangeType` to the property's
  underlying type, with an empty string meaning null/absent; for `Unknown_Segment`, its raw `Elements`
  list, growing it if needed; for the X12 ISA header, its properties directly, since ISA has no
  `[Position]` metadata to walk) -- then renders just that segment back to text with the right mapper
  (`Eddy.x12.Mapping.Map.SegmentToString`/`Eddy.Edifact.Mapping.Map.SegmentToString`,
  `includeTerminator: false`; the ISA header via its own `ToString(MapOptions)`, trimmed of its
  terminator) and splices it in with `SourceEdit.Replace`. Envelope nodes (ISA/GS/ST, UNB/UNG/UNH) edit
  the same way -- a transaction set node's element grid is its ST/UNH header. A value that cannot be
  converted (letters into a numeric element, say) reports a clear message in the status bar and leaves
  the document untouched.
- **Segment delete/insert.** Edit menu, the tree's context menu, and the Delete key (tree focused)
  reach `MainWindowViewModel.DeleteSegmentCommand`/`InsertSegment`. Only a Segment node (not an
  envelope node) can be deleted or used as an insertion point. Insert asks for one line of raw segment
  text without a terminator (e.g. `N9*ZZ*VALUE`) via a small modal; `DocumentEditor` rejects empty text
  or text containing the terminator character. Deleting uses `SourceEdit.Remove` with the document's
  terminator; inserting uses `SourceEdit.InsertAfter`/`InsertBefore`.
- **Automatic control-count fixing.** After a delete or insert on an X12 or EDIFACT document,
  `RecalculateCounts` runs automatically and is folded into the same edit (one undo step, not two),
  unless View > Fix Control Counts Automatically (on by default) is switched off.
- **Explicit recalculation.** Edit > Recalculate Control Counts applies `RecalculateCounts` on demand
  and reports "Updated N trailer values" or "Counts already correct" in the status bar; when a trailer
  is missing entirely (nothing to splice a corrected value into), its name is listed too.

## Save

File > Save (Ctrl+S) writes `DocumentViewModel.RawText` to `FilePath` as UTF-8 without a BOM, with no
newline changes beyond what the loader already normalised on open, and clears `IsDirty`. File > Save
As… (Ctrl+Shift+S) asks `IFilePicker.PickSaveFileAsync(title, suggestedFileName)` for a path (see
`Views/StorageProviderFilePicker.cs`) and adopts it, so a later Ctrl+S writes straight there. A
document with no `FilePath` yet -- a sample, or a generated acknowledgment tab -- has Save fall back to
Save As automatically. Closing a dirty tab, or exiting with any dirty tab open, asks to confirm first
(a plain Yes/No window in `Views/MainWindow.axaml.cs`; `DocumentViewModel.IsDirty` is all the view
model exposes for this, the confirmation itself is a view concern).

## Acknowledgments

Tools > Generate 997 parses the active X12 document leniently (`x12Document.Parse`, same as the
loader) and runs it through
`Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments.FunctionalAcknowledgmentBuilder` with
default `AcknowledgmentOptions`, opening the resulting 997 Functional Acknowledgment as a new tab named
"997 for `<DisplayName>`" with no `FilePath` (so Save As applies). Generate 999 does the same with
`ImplementationAcknowledgmentBuilder`, and is enabled only when the active document's first functional
group is version 005010 or higher (a 999 Implementation Acknowledgment has no meaning for older
versions). Both commands are disabled for EDIFACT and Unknown-format documents. A builder error is
reported in the status bar rather than crashing. This is the one place Eddy.Notepad references a
Eddy.x12.DomainModels.* assembly (see "Dependencies" above); it costs one extra project reference, not
the whole domain model surface.

## View model contract

Views bind only to these types. The loader fills them. Keep property names stable; both the views
task and the core task were written against this list.

    MainWindowViewModel
      Documents, ActiveDocument, StatusText, SampleNames, HasDocuments, LoadedPacks,
      FixControlCountsAutomatically
      OpenFileCommand, OpenSampleCommand(string), CloseDocumentCommand(DocumentViewModel),
      LoadMetadataPackCommand, SaveCommand, SaveAsCommand, UndoCommand, RedoCommand,
      DeleteSegmentCommand, RecalculateControlCountsCommand,
      GenerateFunctionalAcknowledgmentCommand (+ CanGenerateFunctionalAcknowledgment),
      GenerateImplementationAcknowledgmentCommand (+ CanGenerateImplementationAcknowledgment)
      OpenPathAsync(path), OpenText(text, displayName, filePath), RegisterLoadedPack(PackInfoViewModel),
      ApplyTextEdit(document, newText, description), SetElementValue(document, node, element, newValue),
      InsertSegment(before, rawSegmentText)

    DocumentViewModel
      DisplayName, FilePath, Format, RawText, RawLines, Nodes, Diagnostics
      ErrorCount, WarningCount, IsValid, Summary
      SelectedNode, SelectedRawLine, SelectedElements
      IsDirty, CanUndo, CanRedo, UndoStack, RedoStack, SavedText, TabTitle

    DocumentNodeViewModel   Kind, Code, Title, Subtitle, LineNumber, Model, Children, Elements,
                            Diagnostics, ErrorCount, HasErrors, IsExpanded, IsSelected
    ElementViewModel        Reference, Position, Name, PropertyName, Value, HasValue, IsComposite,
                            Components, HasError, DataElementNumber, HasDataElementNumber,
                            DataTypeLabel, Requirement, CodeDescription, Origin, Meaning,
                            IsUnrecognizedCode, MeaningIsDimmed, IsEditing, EditText
    RawLineViewModel        LineNumber, Text, Node, HasError
    DiagnosticViewModel     Severity, LineNumber, SegmentCode, Message, Node, Location
    PackInfoViewModel       Name, Standard, Version, Source

## Loader contract

`DocumentLoader.Load(text, displayName, filePath)` must never throw. Everything Eddy cannot handle
becomes a diagnostic. It parses X12 with `x12Document.Parse(text, new x12ParseOptions { Lenient = true })`
and EDIFACT with `EdiFactDocument.Parse(text, new EdifactParseOptions { Lenient = true })`; both never
throw for content problems in lenient mode (a bad file still produces a `ValidationResult`, not an
exception) -- the loader keeps only one outer catch-all, as a last resort for something unanticipated.

The X12 and EDIFACT pipelines share the same shape: normalise and detect the format once, then build a
tree, raw lines and diagnostics from whichever document the right parser produced. Rules 1-3 and 6-7
below are literally shared code (`DocumentLoader.cs`); rules 4-5 are two parallel implementations
(`DocumentLoader.X12.cs`, `DocumentLoader.Edifact.cs`) that read alike -- same method names and shapes,
Eddy.Edifact model types in place of Eddy.x12 ones.

1. Normalise: strip a UTF-8 BOM, normalise CRLF to LF, trim leading and trailing whitespace. (Both
   parsers tolerate leading whitespace themselves now, but the loader still needs clean text to detect
   the format from the first three characters and, if parsing fails outright, to fall back to a plain
   split.)
2. Detect the format from the first three characters: `ISA` is X12, `UNA` or `UNB` is EDIFACT,
   anything else is Unknown. X12 and EDIFACT both parse fully. Unknown still produces a document with
   raw lines, no tree, and one Info diagnostic saying the format is not supported.
3. Raw lines come from the parser's `Source` spans (`Eddy.Core.SegmentSource`, via `ISourceTracked`),
   not from re-splitting the text: collect every parsed object that carries a `Source` and order them
   by `Source.LineNumber`, building one `RawLineViewModel` per span with `Text = Source.RawText`. For
   X12 that is the ISA header, every GS header, every ST header, every segment (including
   `Unknown_Segment` instances), every SE/GE/IEA trailer and every orphan segment, across all of
   `document.Interchanges`. For EDIFACT it is the same shape one level deeper: the UNA service string
   advice (`document.ServiceStringAdvice`, when present -- it carries its own `Source` even though it
   is not an `EdifactSegment`), the UNB header, every UNG header, every UNH header, every segment
   (including `Unknown_Segment`), every UNT/UNE/UNZ trailer and every orphan segment, across all of
   `document.Interchanges`. This is exactly the convention `ValidationResult.LineNumber` uses (non-blank
   segments, numbered from 1 starting at the interchange header, or at UNA when there is one), so
   `RawLineViewModel.LineNumber` still matches it. When the parser stopped early -- X12's invalid ISA in
   lenient mode leaves `Interchanges` empty or, in a multi-interchange file, partial -- there are no
   spans for the rest of the file, so fall back to the old newline/terminator split so the raw view
   still shows the whole file. `EdiFactDocument.Parse` does not have an equivalent failure mode in
   lenient mode (even an unparseable UNB still gets an `EdifactInterchange`, with a null Header, so the
   rest of the file keeps producing spans), so the EDIFACT path never takes this fallback.
4. Tree.
   - X12, built directly from `document.Interchanges`: one Interchange node per `x12Interchange` (Code
     "ISA", Model = its Header), one FunctionalGroup node per `x12FunctionalGroup` (Code "GS"; a group
     whose Header is null -- a missing GS, recorded only in lenient mode -- gets the title
     "GS (missing)" and a subtitle saying so), one TransactionSet node per `Section` (Model = the
     Section, Elements from the ST header, title "ST 204", subtitle control number and segment count),
     and one Segment node per segment in `Section.Segments`. `Interchange.OrphanSegments` and
     `FunctionalGroup.OrphanSegments` (segments the parser found outside any transaction set, or
     outside any group) become Segment nodes under their container, placed by line number among their
     siblings, with their subtitle prefixed "(outside any transaction set) ". SE/GE/IEA trailers never
     get their own node: instead their line number is mapped to the node they close (transaction set,
     group, or interchange), so a diagnostic on a trailer line lands on that node, not nowhere.
   - EDIFACT, built directly from `document.Interchanges`: one Interchange node per `EdifactInterchange`
     (Code "UNB", Model = its Header; the UNA line, when present, also maps to this node -- there is one
     `ServiceStringAdvice` for the whole document, attached to the first interchange), one
     FunctionalGroup node per `FunctionalGroup` (Code "UNG"; a group whose Header is null -- the
     implicit group used for messages not wrapped in an explicit UNG/UNE pair -- gets the title
     "Messages" and subtitle "no UNG group header"), one TransactionSet node per `Message` (Code =
     `Message.MessageType`, e.g. "INVOIC"; Model = the Message; Elements from the UNH header; title
     "UNH {MessageType}"; subtitle the message reference, version and segment count), and one Segment
     node per segment in `Message.Segments`. `EdifactInterchange.OrphanSegments` and
     `FunctionalGroup.OrphanSegments` become Segment nodes the same way as X12's, subtitle prefixed
     "(outside any message) ". UNT/UNE/UNZ trailers never get their own node, same rule as X12's
     SE/GE/IEA: their line maps to the node they close (message, group, or interchange).
   - Both: `Unknown_Segment` instances (an unrecognised segment code, lenient mode only -- Eddy.x12's
     and Eddy.Edifact's are different types with the same shape, `SegmentId` + `Elements`) become
     Segment nodes titled "{SegmentId} Unknown segment" with elements built from their `Elements` list.
5. Elements (`Services/SegmentElementReader.cs`). Element structure comes from
   `MetadataCatalog.Describe(model.GetType())` (Eddy.Core.Metadata; see docs/metadata-packs.md and
   "Metadata" above), not raw reflection: positions, references and names are the same as before
   (derived from `[Position]`/`Eddy.Core.Attributes.PositionAttribute`, ordered by position; Reference is
   code + two-digit position, "N101" or "NAD01" for EDIFACT; Name is the property name split on capitals,
   "EntityIdentifierCode" -> "Entity Identifier Code", trailing digits kept), plus whatever a loaded pack
   overlays: `DataElementNumber`, `DataTypeLabel` (e.g. "ID 1..3", "AN 1..35", "N0", "DT", "R 1..15", or ""
   when unknown), `Requirement` ("M"/"O"/"C"/""), `CodeDescription` (via `MetadataCatalog.DescribeCode`
   for the element's data element and value, when it has a code list) and `Origin` ("derived", or the
   name of the pack that overlaid it). Values still come from the model instance by reflecting the
   definition's `PropertyName`. A definition with `DataType == Composite` is a composite: recurse into
   its `Components` for the sub-elements and set Value to the joined component values. Include absent
   elements so the grid shows the whole segment definition. The X12 ISA header has no `[Position]`
   attributes, so `MetadataCatalog.Describe` returns no elements for it; the reader falls back to listing
   all its public string/int properties in declaration order instead -- every EDIFACT header
   (UNB/UNG/UNH/UNT/UNE/UNZ) has `[Position]` attributes, so none of them need this fallback.
6. Diagnostics. Each `ValidationResult` in `document.ValidationErrors` becomes one DiagnosticViewModel
   per `Error`, with the result's LineNumber, `result.SegmentCode` (falling back to the raw line's
   leading identifier only when that's null), and `error.ToString()` as the message. The node is the
   one whose line number matches (via the raw line -- see rule 4 for how trailer lines resolve to a
   container node). Severity is Warning for `ErrorCodes.MissingTrailer` and
   `ErrorCodes.SegmentOutsideTransactionSet` (X12), or `ErrorCodes.EdiFactUnsupportedVersion`,
   `ErrorCodes.EdiFactMissingTrailer` and `ErrorCodes.EdiFactSegmentOutsideMessage` (EDIFACT), Error for
   everything else (compare `ErrorCodes` by reference). Element HasError uses `Error.PropertyName` and
   `Error.ElementPosition` (set by `Eddy.Core.Validation.BasicValidator`) instead of a message-contains
   check: an element is in error when a diagnostic on its segment has PropertyName equal to the
   element's PropertyName, or ElementPosition equal to its Position.
7. Summary and Format handle several interchanges and groups: "X12 004010 · 2 interchanges · 3 groups
   · 5 transaction sets · 1 error", or "EDIFACT D96A · 2 interchanges · 3 groups · 5 messages · 1 error"
   for EDIFACT (the wording changes from "transaction set" to "message"; MainWindowViewModel's status
   line wording follows the same rule, keyed off whether Format starts with "EDIFACT"). X12's Format
   uses the first group's version when there is one, else plain "X12". EDIFACT's Format uses the first
   message's declared standards version (`Message.Version`, e.g. "D96A"; this is the version as declared
   in the UNH, not necessarily the version whose segment models were actually used if it needed a
   fallback -- `EdiFactDocument` does not expose the resolved version separately), else plain "EDIFACT".

Selection sync lives in `ViewModels/DocumentViewModel.Selection.cs` (a partial class): implement
`OnSelectedNodeChanged` and `OnSelectedRawLineChanged` so each updates the other without
re-entering, and raise `SelectedElements` changed.

## Sample files

Three cleaned X12 004010 files sit in Samples/. They have fixed-width ISA lines and correct SE, GE
and IEA trailers. 204 and 210 use newline as the segment terminator; 214 uses `~` with a newline
after it for readability, which Eddy handles because it trims each piece.

One EDIFACT D96A file, Sample-INVOIC-Invoice.edi, sits alongside them: a UNA service string advice
followed by a single UNB...UNZ interchange holding one INVOIC message (UNH, BGM, DTM, two NAD lines
with composites, two LIN/QTY/MOA line items, UNS, a total MOA, CNT, UNT). It uses `'` as the segment
terminator with a newline after each segment, correct UNT and UNZ counts, and one value (the supplier
NAD's party name) that uses the release character to escape a literal `+`. It parses with zero errors.
