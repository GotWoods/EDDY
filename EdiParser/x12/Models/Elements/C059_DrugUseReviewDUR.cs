using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C059")]
public class C059_DrugUseReviewDUR : EdiX12Component
{
    [Position(00)]
    public string ReasonForServiceCode { get; set; }

    [Position(01)]
    public string ProfessionalServiceCode { get; set; }

    [Position(02)]
    public string ResultOfServiceCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C059_DrugUseReviewDUR>(this);
        validator.Required(x => x.ReasonForServiceCode);
        validator.Required(x => x.ProfessionalServiceCode);
        validator.Required(x => x.ResultOfServiceCode);
        validator.Length(x => x.ReasonForServiceCode, 2);
        validator.Length(x => x.ProfessionalServiceCode, 2);
        validator.Length(x => x.ResultOfServiceCode, 2);
        return validator.Results;
    }
}