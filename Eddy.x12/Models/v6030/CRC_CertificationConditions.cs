using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("CRC")]
public class CRC_ConditionsIndicator : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string ConditionIndicatorCode { get; set; }

	[Position(04)]
	public string ConditionIndicatorCode2 { get; set; }

	[Position(05)]
	public string ConditionIndicatorCode3 { get; set; }

	[Position(06)]
	public string ConditionIndicatorCode4 { get; set; }

	[Position(07)]
	public string ConditionIndicatorCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRC_ConditionsIndicator>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.ConditionIndicatorCode);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		validator.Length(x => x.ConditionIndicatorCode2, 2, 3);
		validator.Length(x => x.ConditionIndicatorCode3, 2, 3);
		validator.Length(x => x.ConditionIndicatorCode4, 2, 3);
		validator.Length(x => x.ConditionIndicatorCode5, 2, 3);
		return validator.Results;
	}
}
