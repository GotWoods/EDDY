using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("MEM")]
public class MEM_MembershipDetails : EdifactSegment
{
	[Position(1)]
	public string MembershipQualifier { get; set; }

	[Position(2)]
	public C942_MembershipCategory MembershipCategory { get; set; }

	[Position(3)]
	public C944_MembershipStatus MembershipStatus { get; set; }

	[Position(4)]
	public C945_MembershipLevel MembershipLevel { get; set; }

	[Position(5)]
	public C203_RateTariffClass RateTariffClass { get; set; }

	[Position(6)]
	public C960_ReasonForChange ReasonForChange { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MEM_MembershipDetails>(this);
		validator.Required(x=>x.MembershipQualifier);
		validator.Length(x => x.MembershipQualifier, 1, 3);
		return validator.Results;
	}
}
