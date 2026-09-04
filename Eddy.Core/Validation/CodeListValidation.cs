using System.Collections.Generic;
using Eddy.Core.Metadata;

namespace Eddy.Core.Validation;

/// <summary>
/// Shared implementation behind <c>x12ParseOptions.CodeListChecking</c> and
/// <c>EdifactParseOptions.CodeListChecking</c>: after a segment's own Validate() has run, walk its
/// (derived + pack-overlaid) metadata and flag any element - including composite components - whose
/// value is not in its code list, when one is loaded. Silent for elements with no CodeListId, and for
/// elements whose CodeListId has no code list loaded into <see cref="MetadataCatalog.Default"/>.
/// </summary>
public static class CodeListValidation
{
    /// <summary>Checks <paramref name="segment"/> against <see cref="MetadataCatalog.Default"/> for
    /// <paramref name="standard"/>/<paramref name="version"/>, adding an <see cref="Error"/> with
    /// <see cref="ErrorCodes.UnknownCodeValue"/> to <paramref name="result"/> for every element (or
    /// composite component) whose value is not in its loaded code list. A no-op when
    /// <paramref name="mode"/> is <see cref="CodeListChecking.Off"/>, or when <paramref name="standard"/>
    /// or <paramref name="version"/> is unknown.</summary>
    public static void CheckSegment(ValidationResult result, object segment, string standard, string version, CodeListChecking mode)
    {
        if (mode == CodeListChecking.Off || segment == null || standard == null || version == null || result == null)
            return;

        var definition = MetadataCatalog.Default.Describe(segment.GetType());
        CheckElements(result, segment, definition.Id, definition.Elements, standard, version, mode);
    }

    private static void CheckElements(ValidationResult result, object obj, string segmentId, List<ElementDefinition> elements, string standard, string version, CodeListChecking mode)
    {
        if (obj == null || elements == null)
            return;

        var type = obj.GetType();
        foreach (var elem in elements)
        {
            if (string.IsNullOrEmpty(elem.PropertyName))
                continue;

            var property = type.GetProperty(elem.PropertyName);
            if (property == null)
                continue;

            if (elem.DataType == ElementDataType.Composite)
            {
                var child = property.GetValue(obj);
                CheckElements(result, child, segmentId, elem.Components, standard, version, mode);
                continue;
            }

            if (string.IsNullOrEmpty(elem.CodeListId))
                continue;

            var raw = property.GetValue(obj);
            var value = raw == null ? null : raw.ToString();
            if (string.IsNullOrEmpty(value))
                continue;

            var codes = MetadataCatalog.Default.GetCodes(standard, version, elem.CodeListId);
            if (codes == null) // no code list loaded for this element - silent
                continue;

            if (codes.ContainsKey(value))
                continue;

            var formattedName = elem.Position > 0
                ? $"{elem.PropertyName} ({segmentId}-{elem.Position})"
                : elem.PropertyName;
            var severity = mode == CodeListChecking.Error ? ErrorSeverity.Error : ErrorSeverity.Warning;

            result.Add(new Error(ErrorCodes.UnknownCodeValue, formattedName, value, elem.CodeListId)
            {
                Severity = severity,
                PropertyName = elem.PropertyName,
                ElementPosition = elem.Position,
            });
        }
    }
}
