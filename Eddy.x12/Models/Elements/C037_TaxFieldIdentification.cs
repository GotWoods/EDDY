using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C037")]
public class C037_TaxFieldIdentification : EdiX12Component
{
    [Position(00)]
    public string TaxInformationIdentificationNumber { get; set; }

    [Position(01)]
    public string ApplicationErrorConditionCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C037_TaxFieldIdentification>(this);
        validator.Required(x => x.TaxInformationIdentificationNumber);
        validator.Length(x => x.TaxInformationIdentificationNumber, 1, 30);
        validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
        return validator.Results;
    }
}