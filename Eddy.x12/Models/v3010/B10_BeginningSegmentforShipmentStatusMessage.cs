using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("B10")]
public class B10_BeginningSegmentForShipmentStatusMessage : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public int? InquiryRequestNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B10_BeginningSegmentForShipmentStatusMessage>(this);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.ShipmentIdentificationNumber);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.InquiryRequestNumber, 1, 3);
		return validator.Results;
	}
}
