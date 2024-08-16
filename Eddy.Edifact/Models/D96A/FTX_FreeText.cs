using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("FTX")]
public class FTX_FreeText : EdifactSegment
{
	[Position(1)]
	public string TextSubjectQualifier { get; set; }

	[Position(2)]
	public string TextFunctionCoded { get; set; }

	[Position(3)]
	public C107_TextReference TextReference { get; set; }

	[Position(4)]
	public C108_TextLiteral TextLiteral { get; set; }

	[Position(5)]
	public string LanguageCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FTX_FreeText>(this);
		validator.Required(x=>x.TextSubjectQualifier);
		validator.Length(x => x.TextSubjectQualifier, 1, 3);
		validator.Length(x => x.TextFunctionCoded, 1, 3);
		validator.Length(x => x.LanguageCoded, 1, 3);
		return validator.Results;
	}
}
