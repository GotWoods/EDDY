using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C069")]
public class C069_CompositeStateOrProvinceCode : EdiX12Component
{
    [Position(00)]
    public string StateOrProvinceCode { get; set; }

    [Position(01)]
    public string StateOrProvinceCode2 { get; set; }

    [Position(02)]
    public string StateOrProvinceCode3 { get; set; }

    [Position(03)]
    public string StateOrProvinceCode4 { get; set; }

    [Position(04)]
    public string StateOrProvinceCode5 { get; set; }

    [Position(05)]
    public string StateOrProvinceCode6 { get; set; }

    [Position(06)]
    public string StateOrProvinceCode7 { get; set; }

    [Position(07)]
    public string StateOrProvinceCode8 { get; set; }

    [Position(08)]
    public string StateOrProvinceCode9 { get; set; }

    [Position(09)]
    public string StateOrProvinceCode10 { get; set; }

    [Position(10)]
    public string StateOrProvinceCode11 { get; set; }

    [Position(11)]
    public string StateOrProvinceCode12 { get; set; }

    [Position(12)]
    public string StateOrProvinceCode13 { get; set; }

    [Position(13)]
    public string StateOrProvinceCode14 { get; set; }

    [Position(14)]
    public string StateOrProvinceCode15 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C069_CompositeStateOrProvinceCode>(this);
        validator.Required(x => x.StateOrProvinceCode);
        validator.Length(x => x.StateOrProvinceCode, 2);
        validator.Length(x => x.StateOrProvinceCode2, 2);
        validator.Length(x => x.StateOrProvinceCode3, 2);
        validator.Length(x => x.StateOrProvinceCode4, 2);
        validator.Length(x => x.StateOrProvinceCode5, 2);
        validator.Length(x => x.StateOrProvinceCode6, 2);
        validator.Length(x => x.StateOrProvinceCode7, 2);
        validator.Length(x => x.StateOrProvinceCode8, 2);
        validator.Length(x => x.StateOrProvinceCode9, 2);
        validator.Length(x => x.StateOrProvinceCode10, 2);
        validator.Length(x => x.StateOrProvinceCode11, 2);
        validator.Length(x => x.StateOrProvinceCode12, 2);
        validator.Length(x => x.StateOrProvinceCode13, 2);
        validator.Length(x => x.StateOrProvinceCode14, 2);
        validator.Length(x => x.StateOrProvinceCode15, 2);
        return validator.Results;
    }
}