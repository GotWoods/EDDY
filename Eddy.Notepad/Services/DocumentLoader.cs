using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Services;

/// <summary>
/// Parses EDI text with the Eddy libraries and builds the tree, raw lines and diagnostics.
/// See README.md, "Loader contract", for the rules this must follow.
/// </summary>
public sealed class DocumentLoader : IDocumentLoader
{
    public DocumentViewModel Load(string text, string displayName, string? filePath)
    {
        // TODO(core): implement per README.md.
        throw new NotImplementedException();
    }
}
