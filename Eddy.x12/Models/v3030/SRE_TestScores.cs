using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SRE")]
public class SRE_TestScores : EdiX12Segment
{
	[Position(01)]
	public string TestScoreQualifierCode { get; set; }

	[Position(02)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SRE_TestScores>(this);
		validator.Required(x=>x.TestScoreQualifierCode);
		validator.Required(x=>x.FreeFormMessage);
		validator.Length(x => x.TestScoreQualifierCode, 1);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		return validator.Results;
	}
}
