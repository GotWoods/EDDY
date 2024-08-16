using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("COT")]
public class COT_ContributionDetails : EdifactSegment
{
	[Position(1)]
	public string ContributionQualifier { get; set; }

	[Position(2)]
	public C953_ContributionType ContributionType { get; set; }

	[Position(3)]
	public C522_Instruction Instruction { get; set; }

	[Position(4)]
	public C203_RateTariffClass RateTariffClass { get; set; }

	[Position(5)]
	public C960_ReasonForChange ReasonForChange { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COT_ContributionDetails>(this);
		validator.Required(x=>x.ContributionQualifier);
		validator.Length(x => x.ContributionQualifier, 1, 3);
		return validator.Results;
	}
}
