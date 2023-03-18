using EdiParser.Attributes;
using EdiParser.EdiFact.Models.Elements;
using EdiParser.Validation;

namespace EdiParser.EdiFact.Models.Beta;

public class CNT_ControlTotal
{
    [Position(1)]
    public C270_Control Control { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<CNT_ControlTotal>(this);
    }
}