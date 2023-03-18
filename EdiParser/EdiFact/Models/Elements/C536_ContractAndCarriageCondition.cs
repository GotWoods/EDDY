using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.EdiFact.Models.Elements;

public class C536_ContractAndCarriageCondition : IElement
{
    [Position(1)]
    public string ContractAndCarriageConditionCode { get; set; }

    [Position(2)]
    public string CodeListIdentificationCode { get; set; }

    [Position(3)]
    public string CodeListResponsibleAgencyCode { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<C536_ContractAndCarriageCondition>(this);
        validator.Length(x => x.ContractAndCarriageConditionCode, 1, 3);
        validator.Length(x => x.CodeListIdentificationCode, 1, 17);
        validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
    }
}