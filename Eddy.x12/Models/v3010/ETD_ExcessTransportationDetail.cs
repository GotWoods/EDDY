using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ETD")]
public class ETD_ExcessTransportationDetail : EdiX12Segment
{
	[Position(01)]
	public string ExcessTransportationReasonCode { get; set; }

	[Position(02)]
	public string ExcessTransportationResponsibilityCode { get; set; }

	[Position(03)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public string ReturnableContainerFreightPaymentResponsibilityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ETD_ExcessTransportationDetail>(this);
		validator.Required(x=>x.ExcessTransportationReasonCode);
		validator.Required(x=>x.ExcessTransportationResponsibilityCode);
		validator.Length(x => x.ExcessTransportationReasonCode, 1, 2);
		validator.Length(x => x.ExcessTransportationResponsibilityCode, 1);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReturnableContainerFreightPaymentResponsibilityCode, 1, 2);
		return validator.Results;
	}
}
