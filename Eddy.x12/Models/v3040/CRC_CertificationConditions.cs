using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("CRC")]
public class CRC_ConditionsIndicator : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string ConditionIndicator { get; set; }

	[Position(04)]
	public string ConditionIndicator2 { get; set; }

	[Position(05)]
	public string ConditionIndicator3 { get; set; }

	[Position(06)]
	public string ConditionIndicator4 { get; set; }

	[Position(07)]
	public string ConditionIndicator5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRC_ConditionsIndicator>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.ConditionIndicator);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ConditionIndicator, 2);
		validator.Length(x => x.ConditionIndicator2, 2);
		validator.Length(x => x.ConditionIndicator3, 2);
		validator.Length(x => x.ConditionIndicator4, 2);
		validator.Length(x => x.ConditionIndicator5, 2);
		return validator.Results;
	}
}
