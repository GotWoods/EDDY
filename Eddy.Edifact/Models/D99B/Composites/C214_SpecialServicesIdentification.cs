using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C214")]
public class C214_SpecialServicesIdentification : EdifactComponent
{
	[Position(1)]
	public string SpecialServiceDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string SpecialServiceDescription { get; set; }

	[Position(5)]
	public string SpecialServiceDescription2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C214_SpecialServicesIdentification>(this);
		validator.Length(x => x.SpecialServiceDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.SpecialServiceDescription, 1, 35);
		validator.Length(x => x.SpecialServiceDescription2, 1, 35);
		return validator.Results;
	}
}
