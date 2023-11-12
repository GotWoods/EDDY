using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("RAP")]
public class RAP_RequirementAttributeAndProficiency : EdiX12Segment
{
	[Position(01)]
	public string EducationalTestOrRequirementCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string Name2 { get; set; }

	[Position(04)]
	public string UsageIndicator { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(06)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(07)]
	public string DateTimePeriod { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RAP_RequirementAttributeAndProficiency>(this);
		validator.Required(x=>x.EducationalTestOrRequirementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.EducationalTestOrRequirementCode, 1, 3);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Name2, 1, 60);
		validator.Length(x => x.UsageIndicator, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		return validator.Results;
	}
}
