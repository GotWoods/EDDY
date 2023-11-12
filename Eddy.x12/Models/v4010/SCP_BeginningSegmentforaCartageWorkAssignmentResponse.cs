using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SCP")]
public class SCP_BeginningSegmentForACartageWorkAssignmentResponse : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ReservationActionCode { get; set; }

	[Position(04)]
	public string ShipmentOrWorkAssignmentDeclineReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCP_BeginningSegmentForACartageWorkAssignmentResponse>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ReservationActionCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReservationActionCode, 1);
		validator.Length(x => x.ShipmentOrWorkAssignmentDeclineReasonCode, 3);
		return validator.Results;
	}
}
