using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C068")]
public class C068_CompositeIngredientInformation : EdiX12Component
{
    [Position(00)]
    public string FreeFormMessageText { get; set; }

    [Position(01)]
    public string LanguageCode { get; set; }

    [Position(02)]
    public string FreeFormMessageText2 { get; set; }

    [Position(03)]
    public string LanguageCode2 { get; set; }

    [Position(04)]
    public string FreeFormMessageText3 { get; set; }

    [Position(05)]
    public string LanguageCode3 { get; set; }

    [Position(06)]
    public string FreeFormMessageText4 { get; set; }

    [Position(07)]
    public string LanguageCode4 { get; set; }

    [Position(08)]
    public string FreeFormMessageText5 { get; set; }

    [Position(09)]
    public string LanguageCode5 { get; set; }

    [Position(10)]
    public string FreeFormMessageText6 { get; set; }

    [Position(11)]
    public string LanguageCode6 { get; set; }

    [Position(12)]
    public string FreeFormMessageText7 { get; set; }

    [Position(13)]
    public string LanguageCode7 { get; set; }

    [Position(14)]
    public string FreeFormMessageText8 { get; set; }

    [Position(15)]
    public string LanguageCode8 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C068_CompositeIngredientInformation>(this);
        validator.Required(x => x.FreeFormMessageText);
        validator.Required(x => x.LanguageCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText2, x => x.LanguageCode2);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText3, x => x.LanguageCode3);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText4, x => x.LanguageCode4);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText5, x => x.LanguageCode5);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText6, x => x.LanguageCode6);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText7, x => x.LanguageCode7);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreeFormMessageText8, x => x.LanguageCode8);
        validator.Length(x => x.FreeFormMessageText, 1, 264);
        validator.Length(x => x.LanguageCode, 2, 3);
        validator.Length(x => x.FreeFormMessageText2, 1, 264);
        validator.Length(x => x.LanguageCode2, 2, 3);
        validator.Length(x => x.FreeFormMessageText3, 1, 264);
        validator.Length(x => x.LanguageCode3, 2, 3);
        validator.Length(x => x.FreeFormMessageText4, 1, 264);
        validator.Length(x => x.LanguageCode4, 2, 3);
        validator.Length(x => x.FreeFormMessageText5, 1, 264);
        validator.Length(x => x.LanguageCode5, 2, 3);
        validator.Length(x => x.FreeFormMessageText6, 1, 264);
        validator.Length(x => x.LanguageCode6, 2, 3);
        validator.Length(x => x.FreeFormMessageText7, 1, 264);
        validator.Length(x => x.LanguageCode7, 2, 3);
        validator.Length(x => x.FreeFormMessageText8, 1, 264);
        validator.Length(x => x.LanguageCode8, 2, 3);
        return validator.Results;
    }
}