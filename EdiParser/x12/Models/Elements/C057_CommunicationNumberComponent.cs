using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C057")]
public class C057_CommunicationNumberComponent : EdiX12Component
{
    [Position(00)]
    public string CommunicationNumberQualifier { get; set; }

    [Position(01)]
    public string CommunicationNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C057_CommunicationNumberComponent>(this);
        validator.IfOneIsFilled_AllAreRequired(x => x.CommunicationNumberQualifier, x => x.CommunicationNumber);
        validator.Length(x => x.CommunicationNumberQualifier, 2);
        validator.Length(x => x.CommunicationNumber, 1, 2048);
        return validator.Results;
    }
}