using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("HC")]
public class HC_HealthCondition : EdiX12Segment
{
	[Position(01)]
	public string IndustryCode { get; set; }

	[Position(02)]
	public string IndustryCode2 { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(06)]
	public string CodeListQualifierCode { get; set; }

	[Position(07)]
	public string CodeListQualifierCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HC_HealthCondition>(this);
		validator.Required(x=>x.IndustryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IndustryCode2, x=>x.CodeListQualifierCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.CodeListQualifierCode2, 1, 3);
		return validator.Results;
	}
}
