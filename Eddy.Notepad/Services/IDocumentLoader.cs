using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Services;

/// <summary>Turns EDI text into a fully populated <see cref="DocumentViewModel"/>. Never throws.</summary>
public interface IDocumentLoader
{
    DocumentViewModel Load(string text, string displayName, string? filePath);
}
