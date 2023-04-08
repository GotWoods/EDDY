using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("AIN")]
public class AIN_Income : EdiX12Segment
{
    [Position(01)] public string TypeOfIncomeCode { get; set; }

    [Position(02)] public string FrequencyCode { get; set; }

    [Position(03)] public decimal? MonetaryAmount { get; set; }

    [Position(04)] public decimal? Quantity { get; set; }

    [Position(05)] public string YesNoConditionOrResponseCode { get; set; }

    [Position(06)] public string ReferenceIdentification { get; set; }

    [Position(07)] public string AmountQualifierCode { get; set; }

    [Position(08)] public string TaxTreatmentCode { get; set; }

    [Position(09)] public decimal? EarningsRateOfPay { get; set; }

    [Position(10)] public string UnitOrBasisForMeasurementCode { get; set; }

    [Position(11)] public decimal? Quantity2 { get; set; }

    [Position(12)] public string IndustryCode { get; set; }

    [Position(13)] public string Description { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AIN_Income>(this);
        validator.Required(x => x.TypeOfIncomeCode);
        validator.Required(x => x.FrequencyCode);
        validator.Required(x => x.MonetaryAmount);
        validator.Length(x => x.TypeOfIncomeCode, 2);
        validator.Length(x => x.FrequencyCode, 1);
        validator.Length(x => x.MonetaryAmount, 1, 18);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.YesNoConditionOrResponseCode, 1);
        validator.Length(x => x.ReferenceIdentification, 1, 80);
        validator.Length(x => x.AmountQualifierCode, 1, 3);
        validator.Length(x => x.TaxTreatmentCode, 1);
        validator.Length(x => x.EarningsRateOfPay, 1, 15);
        validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
        validator.Length(x => x.Quantity2, 1, 15);
        validator.Length(x => x.IndustryCode, 1, 30);
        validator.Length(x => x.Description, 1, 80);
        return validator.Results;
    }
}