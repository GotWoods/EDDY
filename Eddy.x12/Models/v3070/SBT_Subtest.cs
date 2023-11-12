using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("SBT")]
public class SBT_Subtest : EdiX12Segment
{
	[Position(01)]
	public string SubtestCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string TestScoreInterpretationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SBT_Subtest>(this);
		validator.Required(x=>x.SubtestCode);
		validator.Length(x => x.SubtestCode, 5);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.TestScoreInterpretationCode, 1);
		return validator.Results;
	}
}
