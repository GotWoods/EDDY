using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C028")]
public class C028_AssuranceTokenParameters : EdiX12Component
{
    [Position(00)]
    public string AssuranceTokenParameterCode { get; set; }

    [Position(01)]
    public string AssuranceTokenParameterValue { get; set; }

    [Position(02)]
    public string AssuranceTokenParameterCode2 { get; set; }

    [Position(03)]
    public string AssuranceTokenParameterValue2 { get; set; }

    [Position(04)]
    public string AssuranceTokenParameterCode3 { get; set; }

    [Position(05)]
    public string AssuranceTokenParameterValue3 { get; set; }

    [Position(06)]
    public string AssuranceTokenParameterCode4 { get; set; }

    [Position(07)]
    public string AssuranceTokenParameterValue4 { get; set; }

    [Position(08)]
    public string AssuranceTokenParameterCode5 { get; set; }

    [Position(09)]
    public string AssuranceTokenParameterValue5 { get; set; }

    [Position(10)]
    public string AssuranceTokenParameterCode6 { get; set; }

    [Position(11)]
    public string AssuranceTokenParameterValue6 { get; set; }

    [Position(12)]
    public string AssuranceTokenParameterCode7 { get; set; }

    [Position(13)]
    public string AssuranceTokenParameterValue7 { get; set; }

    [Position(14)]
    public string AssuranceTokenParameterCode8 { get; set; }

    [Position(15)]
    public string AssuranceTokenParameterValue8 { get; set; }

    [Position(16)]
    public string AssuranceTokenParameterCode9 { get; set; }

    [Position(17)]
    public string AssuranceTokenParameterValue9 { get; set; }

    [Position(18)]
    public string AssuranceTokenParameterCode10 { get; set; }

    [Position(19)]
    public string AssuranceTokenParameterValue10 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C028_AssuranceTokenParameters>(this);
        validator.Required(x => x.AssuranceTokenParameterCode);
        validator.Required(x => x.AssuranceTokenParameterValue);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue2, x => x.AssuranceTokenParameterCode2);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue3, x => x.AssuranceTokenParameterCode3);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue4, x => x.AssuranceTokenParameterCode4);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue5, x => x.AssuranceTokenParameterCode5);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue6, x => x.AssuranceTokenParameterCode6);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue7, x => x.AssuranceTokenParameterCode7);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue8, x => x.AssuranceTokenParameterCode8);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue9, x => x.AssuranceTokenParameterCode9);
        validator.ARequiresB(x => x.AssuranceTokenParameterValue10, x => x.AssuranceTokenParameterCode10);
        validator.Length(x => x.AssuranceTokenParameterCode, 2);
        validator.Length(x => x.AssuranceTokenParameterValue, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode2, 2);
        validator.Length(x => x.AssuranceTokenParameterValue2, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode3, 2);
        validator.Length(x => x.AssuranceTokenParameterValue3, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode4, 2);
        validator.Length(x => x.AssuranceTokenParameterValue4, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode5, 2);
        validator.Length(x => x.AssuranceTokenParameterValue5, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode6, 2);
        validator.Length(x => x.AssuranceTokenParameterValue6, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode7, 2);
        validator.Length(x => x.AssuranceTokenParameterValue7, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode8, 2);
        validator.Length(x => x.AssuranceTokenParameterValue8, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode9, 2);
        validator.Length(x => x.AssuranceTokenParameterValue9, 1, 64);
        validator.Length(x => x.AssuranceTokenParameterCode10, 2);
        validator.Length(x => x.AssuranceTokenParameterValue10, 1, 64);
        return validator.Results;
    }
}