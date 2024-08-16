using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C218")]
public class C218_HazardousMaterial : EdifactComponent
{
	[Position(1)]
	public string HazardousMaterialClassCodeIdentification { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string HazardousMaterialClass { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C218_HazardousMaterial>(this);
		validator.Length(x => x.HazardousMaterialClassCodeIdentification, 1, 4);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.HazardousMaterialClass, 1, 35);
		return validator.Results;
	}
}