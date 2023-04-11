using Eddy.Core.Attributes;

namespace Eddy.Core.EdiFact.Models.Elements;

public class C106_DocumentMessageIdentification : IElement
{
    [Position(1)]
    public string DocumentIdentifier { get; set; }

    [Position(2)]
    public string VersionIdentifier { get; set; }

    [Position(3)]
    public string RevisionIdentifier { get; set; }
}