using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C071")]
public class C071_CompositeMultipleLanguageTextInformation : EdiX12Component
{
    [Position(01)]
    public string FreeFormMessageText { get; set; }

    [Position(02)]
    public string LanguageCode { get; set; }

    [Position(03)]
    public string FreeFormMessageText2 { get; set; }

    [Position(04)]
    public string LanguageCode2 { get; set; }

    [Position(05)]
    public string FreeFormMessageText3 { get; set; }

    [Position(06)]
    public string LanguageCode3 { get; set; }

    [Position(07)]
    public string FreeFormMessageText4 { get; set; }

    [Position(08)]
    public string LanguageCode4 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C071_CompositeMultipleLanguageTextInformation>(this);
        validator.Required(x => x.FreeFormMessageText);
        validator.Required(x => x.LanguageCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText2, x => x.LanguageCode2);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText3, x => x.LanguageCode3);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText4, x => x.LanguageCode4);
        validator.Length(x => x.FreeFormMessageText, 1, 264);
        validator.Length(x => x.LanguageCode, 2, 3);
        validator.Length(x => x.FreeFormMessageText2, 1, 264);
        validator.Length(x => x.LanguageCode2, 2, 3);
        validator.Length(x => x.FreeFormMessageText3, 1, 264);
        validator.Length(x => x.LanguageCode3, 2, 3);
        validator.Length(x => x.FreeFormMessageText4, 1, 264);
        validator.Length(x => x.LanguageCode4, 2, 3);
        return validator.Results;
    }
}