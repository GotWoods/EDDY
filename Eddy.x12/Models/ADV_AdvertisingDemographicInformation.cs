using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("ADV")]
public class ADV_AdvertisingDemographicInformation : EdiX12Segment
{
    [Position(01)] public string AgencyQualifierCode { get; set; }

    [Position(02)] public string ServiceCharacteristicsQualifier { get; set; }

    [Position(03)] public decimal? RangeMinimum { get; set; }

    [Position(04)] public decimal? RangeMaximum { get; set; }

    [Position(05)] public string Category { get; set; }

    [Position(06)] public string ServiceCharacteristicsQualifier2 { get; set; }

    [Position(07)] public decimal? MeasurementValue { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ADV_AdvertisingDemographicInformation>(this);
        validator.Required(x => x.AgencyQualifierCode);
        validator.Required(x => x.ServiceCharacteristicsQualifier);
        validator.IfOneIsFilled_AllAreRequired(x => x.ServiceCharacteristicsQualifier2, x => x.MeasurementValue);
        validator.Length(x => x.AgencyQualifierCode, 2);
        validator.Length(x => x.ServiceCharacteristicsQualifier, 2, 3);
        validator.Length(x => x.RangeMinimum, 1, 20);
        validator.Length(x => x.RangeMaximum, 1, 20);
        validator.Length(x => x.Category, 1, 6);
        validator.Length(x => x.ServiceCharacteristicsQualifier2, 2, 3);
        validator.Length(x => x.MeasurementValue, 1, 20);
        return validator.Results;
    }
}