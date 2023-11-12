using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("YNQ")]
public class YNQ_YesNoQuestion : EdiX12Segment
{
	[Position(01)]
	public string ConditionIndicatorCode { get; set; }

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

	[Position(08)]
	public string CodeListQualifierCode { get; set; }

	[Position(09)]
	public string IndustryCode { get; set; }

	[Position(10)]
	public string FreeFormMessageText4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<YNQ_YesNoQuestion>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.ARequiresB(x=>x.IndustryCode, x=>x.CodeListQualifierCode);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.FreeFormMessageText2, 1, 264);
		validator.Length(x => x.FreeFormMessageText3, 1, 264);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.FreeFormMessageText4, 1, 264);
		return validator.Results;
	}
}
