using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C953")]
public class C953_ContributionType : EdifactComponent
{
	[Position(1)]
	public string ContributionTypeCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ContributionType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C953_ContributionType>(this);
		validator.Required(x=>x.ContributionTypeCoded);
		validator.Length(x => x.ContributionTypeCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ContributionType, 1, 35);
		return validator.Results;
	}
}
