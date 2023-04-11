using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C055")]
public class C055_TaxServiceNonPaymentExceptionCode : EdiX12Component
{
    [Position(00)]
    public string TaxServiceNonPaymentCode { get; set; }

    [Position(01)]
    public string TaxServiceNonPaymentCode2 { get; set; }

    [Position(02)]
    public string TaxServiceNonPaymentCode3 { get; set; }

    [Position(03)]
    public string TaxServiceNonPaymentCode4 { get; set; }

    [Position(04)]
    public string TaxServiceNonPaymentCode5 { get; set; }

    [Position(05)]
    public string TaxServiceNonPaymentCode6 { get; set; }

    [Position(06)]
    public string TaxServiceNonPaymentCode7 { get; set; }

    [Position(07)]
    public string TaxServiceNonPaymentCode8 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C055_TaxServiceNonPaymentExceptionCode>(this);
        validator.Required(x => x.TaxServiceNonPaymentCode);
        validator.Length(x => x.TaxServiceNonPaymentCode, 1, 3);
        validator.Length(x => x.TaxServiceNonPaymentCode2, 1, 3);
        validator.Length(x => x.TaxServiceNonPaymentCode3, 1, 3);
        validator.Length(x => x.TaxServiceNonPaymentCode4, 1, 3);
        validator.Length(x => x.TaxServiceNonPaymentCode5, 1, 3);
        validator.Length(x => x.TaxServiceNonPaymentCode6, 1, 3);
        validator.Length(x => x.TaxServiceNonPaymentCode7, 1, 3);
        validator.Length(x => x.TaxServiceNonPaymentCode8, 1, 3);
        return validator.Results;
    }
}