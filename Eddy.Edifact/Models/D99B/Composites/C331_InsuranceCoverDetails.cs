using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C331")]
public class C331_InsuranceCoverDetails : EdifactComponent
{
	[Position(1)]
	public string InsuranceCoverIdentification { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string InsuranceCover { get; set; }

	[Position(5)]
	public string InsuranceCover2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C331_InsuranceCoverDetails>(this);
		validator.Length(x => x.InsuranceCoverIdentification, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.InsuranceCover, 1, 35);
		validator.Length(x => x.InsuranceCover2, 1, 35);
		return validator.Results;
	}
}
