using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("POD")]
public class POD_ProofOfDelivery : EdiX12Segment
{
    [Position(01)]
    public string Date { get; set; }

    [Position(02)]
    public string Time { get; set; }

    [Position(03)]
    public string Name { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<POD_ProofOfDelivery>(this);
        validator.Required(x => x.Date);
        validator.Required(x => x.Name);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.Time, 4, 8);
        validator.Length(x => x.Name, 1, 60);
        return validator.Results;
    }
}