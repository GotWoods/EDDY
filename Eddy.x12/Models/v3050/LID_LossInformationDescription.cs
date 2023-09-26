using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("LID")]
public class LID_LossInformationDescription : EdiX12Segment
{
	[Position(01)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(02)]
	public string DateTimePeriod { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	[Position(04)]
	public string IndustryCode2 { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(08)]
	public string Description2 { get; set; }

	[Position(09)]
	public string IndustryCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LID_LossInformationDescription>(this);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.IndustryCode, 1, 20);
		validator.Length(x => x.IndustryCode2, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.IndustryCode3, 1, 20);
		return validator.Results;
	}
}
