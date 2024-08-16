using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C973")]
public class C973_ApplicabilityType : EdifactComponent
{
	[Position(1)]
	public string ApplicabilityTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ApplicabilityTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C973_ApplicabilityType>(this);
		validator.Length(x => x.ApplicabilityTypeDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ApplicabilityTypeDescription, 1, 35);
		return validator.Results;
	}
}
