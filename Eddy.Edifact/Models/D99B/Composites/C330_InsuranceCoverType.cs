using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C330")]
public class C330_InsuranceCoverType : EdifactComponent
{
	[Position(1)]
	public string InsuranceCoverTypeCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C330_InsuranceCoverType>(this);
		validator.Required(x=>x.InsuranceCoverTypeCode);
		validator.Length(x => x.InsuranceCoverTypeCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
