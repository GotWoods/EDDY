using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Services;

/// <summary>
/// Edit &gt; Find (Ctrl+F; see MainWindowViewModel's search region and Views/MainWindow.axaml). Matching is
/// case-insensitive over each node's raw line text and over every element's name and value, including
/// composite components. Stateless: <see cref="Find"/> re-walks the tree fresh every call, in document
/// order (a depth-first walk of <see cref="DocumentViewModel.Nodes"/>/<see cref="DocumentNodeViewModel.Children"/>
/// -- the flat tree, not whichever loop view happens to be showing, so results are the same regardless of
/// View &gt; Show Loops).
/// </summary>
public static class DocumentSearch
{
    /// <summary>Every node in <paramref name="document"/> that matches <paramref name="query"/>, in
    /// document order. Empty for a blank query.</summary>
    public static List<DocumentNodeViewModel> Find(DocumentViewModel document, string query)
    {
        var results = new List<DocumentNodeViewModel>();
        if (string.IsNullOrEmpty(query))
            return results;

        var rawLineByLineNumber = document.RawLines.ToDictionary(r => r.LineNumber, r => r.Text);

        void Visit(DocumentNodeViewModel node)
        {
            if (Matches(node, query, rawLineByLineNumber))
                results.Add(node);
            foreach (var child in node.Children)
                Visit(child);
        }

        foreach (var root in document.Nodes)
            Visit(root);

        return results;
    }

    private static bool Matches(
        DocumentNodeViewModel node, string query, IReadOnlyDictionary<int, string> rawLineByLineNumber)
    {
        if (node.LineNumber is int line
            && rawLineByLineNumber.TryGetValue(line, out var text)
            && text.Contains(query, StringComparison.OrdinalIgnoreCase))
            return true;

        return node.Elements.Any(e => ElementMatches(e, query));
    }

    private static bool ElementMatches(ElementViewModel element, string query)
    {
        if (element.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.Value is not null && element.Value.Contains(query, StringComparison.OrdinalIgnoreCase))
            return true;

        return element.Components.Any(c => ElementMatches(c, query));
    }
}
