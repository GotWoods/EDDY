using Eddy.Core.Attributes;

namespace Eddy.Core.EdiFact.Models.Elements;

public class S004_Date : IElement
{
    [Position(1)]
    public string Date { get; set; }

    [Position(2)]
    public string Time { get; set; }

}