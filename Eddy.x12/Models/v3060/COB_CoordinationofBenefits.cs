using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("COB")]
public class COB_CoordinationOfBenefits : EdiX12Segment
{
	[Position(01)]
	public string PayerResponsibilitySequenceNumberCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string CoordinationOfBenefitsCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COB_CoordinationOfBenefits>(this);
		validator.Length(x => x.PayerResponsibilitySequenceNumberCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.CoordinationOfBenefitsCode, 1);
		return validator.Results;
	}
}
