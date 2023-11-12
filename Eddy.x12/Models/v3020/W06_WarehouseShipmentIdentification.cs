using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("W06")]
public class W06_WarehouseShipmentIdentification : EdiX12Segment
{
	[Position(01)]
	public string ReportingCode { get; set; }

	[Position(02)]
	public string DepositorOrderNumber { get; set; }

	[Position(03)]
	public string ShipmentDate { get; set; }

	[Position(04)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(05)]
	public string AgentShipmentIDNumber { get; set; }

	[Position(06)]
	public string PurchaseOrderNumber { get; set; }

	[Position(07)]
	public string MasterReferenceLinkNumber { get; set; }

	[Position(08)]
	public int? LinkSequenceNumber { get; set; }

	[Position(09)]
	public string SpecialHandlingCode { get; set; }

	[Position(10)]
	public string ShippingDateChangeReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W06_WarehouseShipmentIdentification>(this);
		validator.Required(x=>x.ReportingCode);
		validator.Required(x=>x.DepositorOrderNumber);
		validator.Required(x=>x.ShipmentDate);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MasterReferenceLinkNumber, x=>x.LinkSequenceNumber);
		validator.Length(x => x.ReportingCode, 1);
		validator.Length(x => x.DepositorOrderNumber, 1, 22);
		validator.Length(x => x.ShipmentDate, 6);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.AgentShipmentIDNumber, 1, 12);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.MasterReferenceLinkNumber, 1, 22);
		validator.Length(x => x.LinkSequenceNumber, 6);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.ShippingDateChangeReasonCode, 2);
		return validator.Results;
	}
}
