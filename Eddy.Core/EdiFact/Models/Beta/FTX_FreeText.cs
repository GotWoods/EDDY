using Eddy.Core.Attributes;
using Eddy.Core.EdiFact.Models.Elements;
using Eddy.Core.Validation;

namespace Eddy.Core.EdiFact.Models.Beta;

public class FTX_FreeText
{
    [Position(1)]
    public string TextSubjectCodeQualifier { get; set; }

    [Position(2)]
    public string FreeTextFunctionCode { get; set; }

    [Position(3)]
    public C107_TextReference TextReference { get; set; }

    [Position(4)]
    public C108_TextLiteral TextLiteral { get; set; }

    [Position(5)]
    public string LanguageNameCode { get; set; }

    [Position(6)]
    public string FreeTextFormatCode { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<FTX_FreeText>(this);
        validator.Length(x => x.TextSubjectCodeQualifier, 1, 3);
        validator.Length(x => x.FreeTextFunctionCode, 1, 3);
        validator.Length(x => x.LanguageNameCode, 1, 3);
        validator.Length(x => x.FreeTextFormatCode, 1, 3);
    }
}