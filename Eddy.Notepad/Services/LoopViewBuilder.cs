using System.Collections;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.Notepad.ViewModels;
using Eddy.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Notepad.Services;

/// <summary>
/// Builds <see cref="DocumentNodeViewModel.LoopChildren"/> for an X12 TransactionSet node (View &gt; Show
/// Loops, Ctrl+L): walks the domain-model object graph <see cref="DomainMapper"/> produces for the
/// transaction set's segments, by <see cref="SectionPositionAttribute"/> property in position order, and
/// turns it into a tree of the SAME <see cref="DocumentNodeViewModel"/> instances already built for the
/// flat view -- so selection, diagnostics and the raw-line link keep working -- grouped under new
/// <see cref="NodeKind.Loop"/> nodes for repeating complex loop objects (e.g. "L0100"). Segments the domain
/// model did not expect land under a trailing "Unmapped segments" loop node, each with a Warning
/// diagnostic added both to the segment's own node and to the document's diagnostics list.
///
/// Called only when <c>TransactionSetRegistry.Resolve</c> already found a domain type for the transaction
/// set (see DocumentLoader.X12.cs); a transaction set with no such model keeps only its flat
/// <see cref="DocumentNodeViewModel.Children"/>, in both view modes.
///
/// Eddy.Notepad otherwise references no Eddy.x12.DomainModels.* assembly beyond
/// Eddy.x12.DomainModels.CommunicationsAndControls (see README.md, "Dependencies"); this is the other,
/// deliberate exception (Eddy.x12.DomainModels.Transportation), needed so <c>TransactionSetRegistry</c> has
/// some model to resolve common X12 transaction sets against. <see cref="EnsureAssembliesLoaded"/> must run
/// before the first call to <c>TransactionSetRegistry.Resolve</c> anywhere in this process -- a project
/// reference alone does not load an assembly nothing has touched yet, and <c>TransactionSetRegistry</c>'s
/// AppDomain scan for already-loaded "Eddy.x12.DomainModels.*" assemblies only ever runs once. Registering
/// both assemblies explicitly here (rather than relying on that scan) sidesteps the ordering question
/// entirely: it works whether this runs before or after that scan already has.
/// </summary>
public static class LoopViewBuilder
{
    static LoopViewBuilder()
    {
        TransactionSetRegistry.Register(typeof(Eddy.x12.DomainModels.Transportation.v4010.Edi204_MotorCarrierLoadTender).Assembly);
        TransactionSetRegistry.Register(typeof(Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments.FunctionalAcknowledgmentBuilder).Assembly);
    }

    /// <summary>No-op; calling it guarantees the static constructor above has already run. DocumentLoader.X12.cs
    /// calls this before it builds any transaction set's title or loop view -- see the class remarks.</summary>
    public static void EnsureAssembliesLoaded()
    {
    }

    /// <summary>
    /// Builds the loop view for one TransactionSet node. <paramref name="domainType"/> must already be a
    /// non-null result of <c>TransactionSetRegistry.Resolve</c>; <paramref name="segments"/> is the
    /// transaction set's body (<c>Section.Segments</c>, excluding the ST/SE header/trailer -- the same list
    /// the flat view was already built from); <paramref name="segmentNodes"/> maps each of those segment
    /// instances to the <see cref="DocumentNodeViewModel"/> already built for it, by reference identity.
    /// Any segment <see cref="DomainMapper"/> could not place gets a Warning <see cref="DiagnosticViewModel"/>
    /// added to both its node and <paramref name="documentDiagnostics"/>.
    /// </summary>
    public static List<DocumentNodeViewModel> Build(
        Type domainType,
        string transactionSetCode,
        List<EdiX12Segment> segments,
        IReadOnlyDictionary<EdiX12Segment, DocumentNodeViewModel> segmentNodes,
        ICollection<DiagnosticViewModel> documentDiagnostics)
    {
        var mapper = new DomainMapper(segments);
        var result = mapper.MapWithDiagnostics(domainType);

        var children = WalkObject(result.Value, domainType, segmentNodes);

        if (result.UnmappedSegments.Count > 0)
        {
            var unmappedNode = new DocumentNodeViewModel(NodeKind.Loop, "", "Unmapped segments", "", null, null);

            foreach (var segment in result.UnmappedSegments)
            {
                if (!segmentNodes.TryGetValue(segment, out var node))
                    continue;

                var warning = new DiagnosticViewModel(
                    DiagnosticSeverity.Warning,
                    node.LineNumber,
                    node.Code,
                    $"Segment {node.Code} at line {node.LineNumber} was not expected by the {transactionSetCode} structure")
                {
                    Node = node,
                };
                documentDiagnostics.Add(warning);
                node.Diagnostics.Add(warning);

                unmappedNode.Children.Add(node);
            }

            children.Add(unmappedNode);
        }

        return children;
    }

    /// <summary>Walks <paramref name="type"/>'s [SectionPosition] properties, in position order, reading
    /// each one off <paramref name="instance"/>: a segment becomes its existing node (looked up in
    /// <paramref name="segmentNodes"/>; silently skipped if absent -- this is how the ST/SE header/trailer
    /// properties, which DomainMapper leaves as a freshly-constructed default rather than one of our actual
    /// segment instances, drop out of the loop view without special-casing them), a list of segments
    /// becomes their nodes, and a list of (or single) complex loop object becomes one <see cref="BuildLoopNode"/>
    /// per item.</summary>
    private static List<DocumentNodeViewModel> WalkObject(
        object instance, Type type, IReadOnlyDictionary<EdiX12Segment, DocumentNodeViewModel> segmentNodes)
    {
        var result = new List<DocumentNodeViewModel>();

        var properties = type.GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(SectionPositionAttribute)))
            .OrderBy(p => p.GetCustomAttribute<SectionPositionAttribute>()!.Position);

        foreach (var property in properties)
        {
            var value = property.GetValue(instance);
            if (value is null)
                continue;

            if (value is EdiX12Segment segment)
            {
                if (segmentNodes.TryGetValue(segment, out var node))
                    result.Add(node);
                continue;
            }

            if (value is IList list)
            {
                foreach (var item in list)
                {
                    if (item is EdiX12Segment itemSegment)
                    {
                        if (segmentNodes.TryGetValue(itemSegment, out var itemNode))
                            result.Add(itemNode);
                    }
                    else if (item is not null)
                    {
                        result.Add(BuildLoopNode(item, segmentNodes));
                    }
                }

                continue;
            }

            // A single (non-list) complex loop property. Not seen in the shipped domain models today (every
            // repeating complex loop is a List<T>), but SectionPosition properties are only ever a segment,
            // a list of segments, or a complex loop -- so anything reaching this line is the third case.
            result.Add(BuildLoopNode(value, segmentNodes));
        }

        return result;
    }

    private static DocumentNodeViewModel BuildLoopNode(
        object loopItem, IReadOnlyDictionary<EdiX12Segment, DocumentNodeViewModel> segmentNodes)
    {
        var type = loopItem.GetType();
        var code = type.Name; // e.g. "L0100"
        var children = WalkObject(loopItem, type, segmentNodes);
        var first = children.Count > 0 ? children[0] : null;

        var title = first is not null ? $"{code} {first.Title}" : code;
        var subtitle = first?.Subtitle ?? "";

        var node = new DocumentNodeViewModel(NodeKind.Loop, code, title, subtitle, first?.LineNumber, loopItem);
        foreach (var child in children)
            node.Children.Add(child);

        return node;
    }
}
