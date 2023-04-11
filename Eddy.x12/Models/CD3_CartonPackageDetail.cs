using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CD3")]
public class CD3_CartonPackageDetail : EdiX12Segment
{
    [Position(01)]
    public string WeightQualifier { get; set; }

    [Position(02)]
    public decimal? Weight { get; set; }

    [Position(03)]
    public string Zone { get; set; }

    [Position(04)]
    public string ServiceStandard { get; set; }

    [Position(05)]
    public string ServiceLevelCode { get; set; }

    [Position(06)]
    public string PickupOrDeliveryCode { get; set; }

    [Position(07)]
    public string RateValueQualifier { get; set; }

    [Position(08)]
    public string AmountCharged { get; set; }

    [Position(09)]
    public string RateValueQualifier2 { get; set; }

    [Position(10)]
    public string AmountCharged2 { get; set; }

    [Position(11)]
    public string ServiceLevelCode2 { get; set; }

    [Position(12)]
    public string ServiceLevelCode3 { get; set; }

    [Position(13)]
    public string PaymentMethodCode { get; set; }

    [Position(14)]
    public string CountryCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<CD3_CartonPackageDetail>(this);
        validator.IfOneIsFilled_AllAreRequired(x => x.WeightQualifier, x => x.Weight);
        validator.IfOneIsFilled_AllAreRequired(x => x.RateValueQualifier, x => x.AmountCharged);
        validator.IfOneIsFilled_AllAreRequired(x => x.RateValueQualifier2, x => x.AmountCharged2);
        validator.ARequiresB(x => x.ServiceLevelCode2, x => x.ServiceLevelCode);
        validator.ARequiresB(x => x.ServiceLevelCode3, x => x.ServiceLevelCode2);
        validator.ARequiresB(x => x.CountryCode, x => x.ServiceLevelCode);
        validator.Length(x => x.WeightQualifier, 1, 2);
        validator.Length(x => x.Weight, 1, 10);
        validator.Length(x => x.Zone, 2, 3);
        validator.Length(x => x.ServiceStandard, 1, 4);
        validator.Length(x => x.ServiceLevelCode, 2);
        validator.Length(x => x.PickupOrDeliveryCode, 1, 2);
        validator.Length(x => x.RateValueQualifier, 2);
        validator.Length(x => x.AmountCharged, 1, 15);
        validator.Length(x => x.RateValueQualifier2, 2);
        validator.Length(x => x.AmountCharged2, 1, 15);
        validator.Length(x => x.ServiceLevelCode2, 2);
        validator.Length(x => x.ServiceLevelCode3, 2);
        validator.Length(x => x.PaymentMethodCode, 3);
        validator.Length(x => x.CountryCode, 2, 3);
        return validator.Results;
    }
}