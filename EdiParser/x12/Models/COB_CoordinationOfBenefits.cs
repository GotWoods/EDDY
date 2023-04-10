using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("COB")]
public class COB_CoordinationOfBenefits : EdiX12Segment
{
	[Position(01)]
	public string PayerResponsibilitySequenceNumberCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string CoordinationOfBenefitsCode { get; set; }

	[Position(04)]
	public string ServiceTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COB_CoordinationOfBenefits>(this);
		validator.Length(x => x.PayerResponsibilitySequenceNumberCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.CoordinationOfBenefitsCode, 1);
		validator.Length(x => x.ServiceTypeCode, 1, 2);
		return validator.Results;
	}
}
