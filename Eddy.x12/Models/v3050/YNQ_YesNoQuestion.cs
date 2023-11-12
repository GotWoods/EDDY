using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("YNQ")]
public class YNQ_YesNoQuestion : EdiX12Segment
{
	[Position(01)]
	public string ConditionIndicator { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string FreeFormMessageText { get; set; }

	[Position(06)]
	public string FreeFormMessageText2 { get; set; }

	[Position(07)]
	public string FreeFormMessageText3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<YNQ_YesNoQuestion>(this);
		validator.Required(x=>x.ConditionIndicator);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.ConditionIndicator, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.FreeFormMessageText2, 1, 264);
		validator.Length(x => x.FreeFormMessageText3, 1, 264);
		return validator.Results;
	}
}
