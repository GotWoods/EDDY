using EdiParser.Attributes;
using EdiParser.EdiFact.Models.Elements;
using EdiParser.Validation;

namespace EdiParser.EdiFact.Models.Beta;

public class DTM_DateTimePeriod 
{
    [Position(1)]
    public C507_DateTimePeriod DateTimePeriod { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<DTM_DateTimePeriod> (this);
    }
}