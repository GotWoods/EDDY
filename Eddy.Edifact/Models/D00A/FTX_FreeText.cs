using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("FTX")]
public class FTX_FreeText : EdifactSegment
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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FTX_FreeText>(this);
		validator.Required(x=>x.TextSubjectCodeQualifier);
		validator.Length(x => x.TextSubjectCodeQualifier, 1, 3);
		validator.Length(x => x.FreeTextFunctionCode, 1, 3);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.FreeTextFormatCode, 1, 3);
		return validator.Results;
	}
}
