using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C945")]
public class C945_MembershipLevel : EdifactComponent
{
	[Position(1)]
	public string MembershipLevelQualifier { get; set; }

	[Position(2)]
	public string MembershipLevelIdentification { get; set; }

	[Position(3)]
	public string CodeListQualifier { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(5)]
	public string MembershipLevel { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C945_MembershipLevel>(this);
		validator.Required(x=>x.MembershipLevelQualifier);
		validator.Length(x => x.MembershipLevelQualifier, 1, 3);
		validator.Length(x => x.MembershipLevelIdentification, 1, 9);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.MembershipLevel, 1, 35);
		return validator.Results;
	}
}
