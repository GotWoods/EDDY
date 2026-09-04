using System.Globalization;
using System.Reflection;
using Eddy.Core;
using Eddy.Core.Metadata;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Services;

/// <summary>Thrown for any edit that cannot be applied: an unconvertible value, a segment with no known
/// location in the file, an attempt to delete or insert next to an envelope node, or invalid raw segment
/// text. <see cref="Exception.Message"/> is meant to be shown to the user as-is.</summary>
public sealed class DocumentEditorException : Exception
{
    public DocumentEditorException(string message) : base(message)
    {
    }
}

/// <summary>
/// Turns one logical edit (change an element's value, delete a segment, insert a segment) into new
/// document text: mutate the already-parsed model object in place, render just that segment back to text
/// with the right format-specific mapper, then splice it into the document text with
/// <see cref="SourceEdit"/>. Never mutates <see cref="DocumentViewModel.RawText"/> itself -- callers
/// re-load the returned text through <see cref="IDocumentLoader"/> (see
/// MainWindowViewModel.ApplyTextEdit). Format-aware (X12 vs EDIFACT, keyed off
/// <see cref="DocumentViewModel.Format"/>) and UI-free, so it is testable on its own.
/// </summary>
public sealed class DocumentEditor
{
    private readonly MetadataCatalog _catalog;

    public DocumentEditor(MetadataCatalog? catalog = null)
    {
        _catalog = catalog ?? MetadataCatalog.Default;
    }

    private static bool IsEdifact(DocumentViewModel document) =>
        document.Format.StartsWith("EDIFACT", StringComparison.Ordinal);

    private static bool IsX12(DocumentViewModel document) =>
        document.Format.StartsWith("X12", StringComparison.Ordinal);

    // ---- element editing --------------------------------------------------------------------------------

    /// <summary>Sets one element's value on the model behind <paramref name="node"/> and returns the whole
    /// document text with just that segment's line replaced. Throws <see cref="DocumentEditorException"/>
    /// when the value cannot be converted to the element's type, or the node has no editable model.</summary>
    public string ReplaceElementValue(DocumentViewModel document, DocumentNodeViewModel node, ElementViewModel element, string? newValue)
    {
        if (node.Model is null)
            throw new DocumentEditorException("This node has no editable segment.");

        return IsEdifact(document)
            ? ReplaceElementValueEdifact(document, node, element, newValue)
            : ReplaceElementValueX12(document, node, element, newValue);
    }

    private string ReplaceElementValueX12(DocumentViewModel document, DocumentNodeViewModel node, ElementViewModel element, string? newValue)
    {
        var model = node.Model!;

        if (model is Eddy.x12.Models.GenericInterchangeControlHeader isa)
        {
            SetSimpleProperty(isa, element.PropertyName, newValue);
            var full = isa.ToString();
            var text = full.Length > 0 && full[^1] == isa.ElementSeparator ? full[..^1] : full;
            return SourceEdit.Replace(document.RawText, RequireSource(isa), text);
        }

        if (model is Eddy.x12.Models.Unknown_Segment unknown)
        {
            SetUnknownElement(unknown.Elements, element.Position, newValue);
            var mapOptions = FindX12MapOptions(document, node.LineNumber);
            var text = Eddy.x12.Mapping.Map.SegmentToString(unknown, mapOptions, false);
            return SourceEdit.Replace(document.RawText, RequireSource(unknown), text);
        }

        if (model is Eddy.x12.Models.EdiX12Segment segment)
        {
            var definition = _catalog.Describe(segment.GetType());
            var path = FindPropertyPath(definition.Elements, node.Code, element.Reference)
                ?? throw new DocumentEditorException($"Could not find element {element.Reference} on {node.Code}.");
            SetNestedProperty(segment, path, newValue);
            var mapOptions = FindX12MapOptions(document, node.LineNumber);
            var text = Eddy.x12.Mapping.Map.SegmentToString(segment, mapOptions, false);
            return SourceEdit.Replace(document.RawText, RequireSource(segment), text);
        }

        throw new DocumentEditorException("This node cannot be edited.");
    }

    private string ReplaceElementValueEdifact(DocumentViewModel document, DocumentNodeViewModel node, ElementViewModel element, string? newValue)
    {
        var model = node.Model!;
        var mapOptions = FindEdifactMapOptions(document);

        if (model is Eddy.Edifact.Unknown_Segment unknown)
        {
            SetUnknownElement(unknown.Elements, element.Position, newValue);
            var text = Eddy.Edifact.Mapping.Map.SegmentToString(unknown, mapOptions, false);
            return SourceEdit.Replace(document.RawText, RequireSource(unknown), text);
        }

        if (model is Eddy.Edifact.EdifactSegment segment)
        {
            var definition = _catalog.Describe(segment.GetType());
            var path = FindPropertyPath(definition.Elements, node.Code, element.Reference)
                ?? throw new DocumentEditorException($"Could not find element {element.Reference} on {node.Code}.");
            SetNestedProperty(segment, path, newValue);
            var text = Eddy.Edifact.Mapping.Map.SegmentToString(segment, mapOptions, false);
            return SourceEdit.Replace(document.RawText, RequireSource(segment), text);
        }

        throw new DocumentEditorException("This node cannot be edited.");
    }

    // ---- segment delete/insert ---------------------------------------------------------------------------

    /// <summary>Removes the segment behind <paramref name="node"/>. Envelope nodes (interchange, group,
    /// transaction set/message) cannot be removed.</summary>
    public string RemoveSegment(DocumentViewModel document, DocumentNodeViewModel node)
    {
        if (node.Kind != NodeKind.Segment)
            throw new DocumentEditorException("Envelope segments cannot be deleted.");
        if (node.Model is null)
            throw new DocumentEditorException("This node has no segment to delete.");

        var source = RequireSource(node.Model);
        var terminator = GetTerminator(document, node.LineNumber);
        return SourceEdit.Remove(document.RawText, source, terminator);
    }

    /// <summary>Inserts <paramref name="rawSegmentText"/> (without a terminator) immediately after the
    /// segment behind <paramref name="node"/>.</summary>
    public string InsertSegmentAfter(DocumentViewModel document, DocumentNodeViewModel node, string rawSegmentText) =>
        InsertSegment(document, node, rawSegmentText, before: false);

    /// <summary>Inserts <paramref name="rawSegmentText"/> (without a terminator) immediately before the
    /// segment behind <paramref name="node"/>.</summary>
    public string InsertSegmentBefore(DocumentViewModel document, DocumentNodeViewModel node, string rawSegmentText) =>
        InsertSegment(document, node, rawSegmentText, before: true);

    private string InsertSegment(DocumentViewModel document, DocumentNodeViewModel node, string rawSegmentText, bool before)
    {
        if (node.Kind != NodeKind.Segment)
            throw new DocumentEditorException("Segments can only be inserted next to another segment.");
        if (node.Model is null)
            throw new DocumentEditorException("This node has no segment to insert next to.");
        if (string.IsNullOrWhiteSpace(rawSegmentText))
            throw new DocumentEditorException("Enter the segment text to insert.");

        var source = RequireSource(node.Model);
        var terminator = GetTerminator(document, node.LineNumber);
        if (rawSegmentText.IndexOf(terminator) >= 0)
            throw new DocumentEditorException($"Segment text must not contain the terminator character ('{terminator}').");

        return before
            ? SourceEdit.InsertBefore(document.RawText, source, terminator, rawSegmentText)
            : SourceEdit.InsertAfter(document.RawText, source, terminator, rawSegmentText);
    }

    // ---- control counts -----------------------------------------------------------------------------------

    /// <summary>Recalculates <paramref name="document"/>'s SE/GE/IEA (X12) or UNT/UNE/UNZ (EDIFACT) trailer
    /// values. Returns the input text unchanged, with no changes, for an Unknown-format document.</summary>
    public ControlCountResult RecalculateCounts(DocumentViewModel document) =>
        RecalculateCounts(document.RawText, document.Format);

    /// <summary>Same as <see cref="RecalculateCounts(DocumentViewModel)"/>, for text that has not yet been
    /// loaded into a <see cref="DocumentViewModel"/> (e.g. right after an insert or delete).</summary>
    public static ControlCountResult RecalculateCounts(string text, string format)
    {
        if (format.StartsWith("EDIFACT", StringComparison.Ordinal))
            return Eddy.Edifact.EdiFactDocument.RecalculateControlCounts(text);
        if (format.StartsWith("X12", StringComparison.Ordinal))
            return Eddy.x12.x12Document.RecalculateControlCounts(text);
        return new ControlCountResult { Text = text };
    }

    // ---- separators/terminator ------------------------------------------------------------------------------

    private static char GetTerminator(DocumentViewModel document, int? lineNumber)
    {
        if (IsEdifact(document))
        {
            var options = FindEdifactMapOptions(document);
            if (options.LineEnding is { Length: > 0 } le)
                return le[0];
            throw new DocumentEditorException("Could not determine this document's segment terminator.");
        }

        var mapOptions = FindX12MapOptions(document, lineNumber);
        if (mapOptions.LineEnding is { Length: > 0 } term)
            return term[0];
        throw new DocumentEditorException("Could not determine this document's segment terminator.");
    }

    private static Eddy.x12.Mapping.MapOptions FindX12MapOptions(DocumentViewModel document, int? lineNumber)
    {
        var parsed = Eddy.x12.x12Document.Parse(document.RawText, new Eddy.x12.x12ParseOptions { Lenient = true });
        var interchange = FindOwningInterchange(parsed.Interchanges, lineNumber);
        var options = interchange?.MapOptions
            ?? (interchange?.Header is not null ? Eddy.x12.Mapping.MapOptions.FromInterchangeHeader(interchange.Header) : null);

        return options ?? throw new DocumentEditorException("Could not determine this document's segment separators.");
    }

    private static Eddy.x12.x12Interchange? FindOwningInterchange(List<Eddy.x12.x12Interchange> interchanges, int? lineNumber)
    {
        if (interchanges.Count == 0)
            return null;
        if (lineNumber is null)
            return interchanges[0];

        Eddy.x12.x12Interchange? best = null;
        foreach (var interchange in interchanges)
        {
            var headerLine = interchange.Header?.Source?.LineNumber;
            if (headerLine is int hl && hl <= lineNumber && (best is null || hl > best.Header!.Source!.LineNumber))
                best = interchange;
        }

        return best ?? interchanges[0];
    }

    private static Eddy.Edifact.Mapping.MapOptions FindEdifactMapOptions(DocumentViewModel document)
    {
        var parsed = Eddy.Edifact.EdiFactDocument.Parse(document.RawText, new Eddy.Edifact.EdifactParseOptions { Lenient = true });
        return parsed.MapOptions ?? new Eddy.Edifact.Mapping.MapOptions();
    }

    // ---- reflection helpers -------------------------------------------------------------------------------

    /// <summary>
    /// Finds the chain of property names leading from a segment's root to the element named
    /// <paramref name="targetReference"/> (e.g. "NAD0201" reached via "PartyIdentificationDetails" then
    /// "PartyIdIdentification"), replaying the same "parentReference + rank:D2" scheme
    /// <see cref="SegmentElementReader"/> uses to build references. Null when no element in
    /// <paramref name="definitions"/> (recursively, through composites) has that reference.
    /// </summary>
    private static List<string>? FindPropertyPath(List<ElementDefinition> definitions, string parentReference, string targetReference)
    {
        for (var i = 0; i < definitions.Count; i++)
        {
            var reference = parentReference + (i + 1).ToString("D2");
            if (reference == targetReference)
                return new List<string> { definitions[i].PropertyName };

            if (definitions[i].DataType == ElementDataType.Composite && definitions[i].Components.Count > 0)
            {
                var childPath = FindPropertyPath(definitions[i].Components, reference, targetReference);
                if (childPath is not null)
                {
                    childPath.Insert(0, definitions[i].PropertyName);
                    return childPath;
                }
            }
        }

        return null;
    }

    /// <summary>Walks <paramref name="path"/> from <paramref name="root"/>, creating any missing composite
    /// instance along the way, then sets the final property to <paramref name="newValue"/>.</summary>
    private static void SetNestedProperty(object root, IReadOnlyList<string> path, string? newValue)
    {
        var current = root;
        for (var i = 0; i < path.Count - 1; i++)
        {
            var property = current.GetType().GetProperty(path[i], BindingFlags.Public | BindingFlags.Instance)
                ?? throw new DocumentEditorException($"Property '{path[i]}' was not found.");
            var child = property.GetValue(current);
            if (child is null)
            {
                child = Activator.CreateInstance(property.PropertyType)
                    ?? throw new DocumentEditorException($"Could not create a '{property.PropertyType.Name}' instance.");
                property.SetValue(current, child);
            }

            current = child;
        }

        SetSimpleProperty(current, path[^1], newValue);
    }

    private static void SetSimpleProperty(object target, string propertyName, string? newValue)
    {
        var property = target.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)
            ?? throw new DocumentEditorException($"Property '{propertyName}' was not found.");

        property.SetValue(target, ConvertValue(newValue, property.PropertyType, propertyName));
    }

    /// <summary>Empty/null means absent (null for a nullable property, an error for a non-nullable one).
    /// Otherwise converts to the property's underlying type, wrapping any conversion failure in a
    /// <see cref="DocumentEditorException"/> with a message naming the offending value.</summary>
    private static object? ConvertValue(string? newValue, Type propertyType, string propertyName)
    {
        var underlying = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

        if (string.IsNullOrEmpty(newValue))
        {
            if (propertyType.IsValueType && Nullable.GetUnderlyingType(propertyType) is null)
                throw new DocumentEditorException($"{propertyName} cannot be empty.");
            return null;
        }

        if (underlying == typeof(string))
            return newValue;

        try
        {
            return Convert.ChangeType(newValue, underlying, CultureInfo.InvariantCulture);
        }
        catch (Exception ex) when (ex is FormatException or OverflowException or InvalidCastException)
        {
            throw new DocumentEditorException($"'{newValue}' is not a valid value for {propertyName} ({underlying.Name}).");
        }
    }

    private static void SetUnknownElement(List<string> elements, int position, string? newValue)
    {
        var index = position - 1;
        if (index < 0)
            throw new DocumentEditorException("Invalid element position.");
        while (elements.Count <= index)
            elements.Add("");
        elements[index] = newValue ?? "";
    }

    private static SegmentSource RequireSource(object model) =>
        (model as ISourceTracked)?.Source ?? throw new DocumentEditorException("This segment's location in the file is unknown.");
}
