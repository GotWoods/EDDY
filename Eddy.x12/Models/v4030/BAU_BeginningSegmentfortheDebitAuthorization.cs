using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("BAU")]
public class BAU_BeginningSegmentForTheDebitAuthorization : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string PaymentMethodCode { get; set; }

	[Position(03)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(04)]
	public string DFIIdentificationNumber { get; set; }

	[Position(05)]
	public string AccountNumber { get; set; }

	[Position(06)]
	public string Name { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAU_BeginningSegmentForTheDebitAuthorization>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.PaymentMethodCode);
		validator.Required(x=>x.DFIIDNumberQualifier);
		validator.Required(x=>x.DFIIdentificationNumber);
		validator.Required(x=>x.AccountNumber);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.Name, 1, 60);
		return validator.Results;
	}
}
