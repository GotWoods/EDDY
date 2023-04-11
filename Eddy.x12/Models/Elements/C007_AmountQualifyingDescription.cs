using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C007")]
public class C007_AmountQualifyingDescription : EdiX12Component
{
    [Position(00)]
    public string AmountQualifierCode { get; set; }

    [Position(01)]
    public string AmountQualifierCode2 { get; set; }

    [Position(02)]
    public string ValueDetailCode { get; set; }

    [Position(03)]
    public string MeasurementSignificanceCode { get; set; }

    [Position(04)]
    public string UnitOfTimePeriodOrInterval { get; set; }

    [Position(05)]
    public string NetGrossCode { get; set; }

    [Position(06)]
    public string MeasurementSignificanceCode2 { get; set; }

    [Position(07)]
    public string Description { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C007_AmountQualifyingDescription>(this);
        validator.Required(x => x.AmountQualifierCode);
        validator.Length(x => x.AmountQualifierCode, 1, 3);
        validator.Length(x => x.AmountQualifierCode2, 1, 3);
        validator.Length(x => x.ValueDetailCode, 1);
        validator.Length(x => x.MeasurementSignificanceCode, 2);
        validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
        validator.Length(x => x.NetGrossCode, 1);
        validator.Length(x => x.MeasurementSignificanceCode2, 2);
        validator.Length(x => x.Description, 1, 80);
        return validator.Results;
    }
}