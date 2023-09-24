using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("W17")]
public class W17_WarehouseReceiptIdentification : EdiX12Segment
{
	[Position(01)]
	public string ReportingCode { get; set; }

	[Position(02)]
	public string DateOfReceipt { get; set; }

	[Position(03)]
	public string WarehouseReceiptNumber { get; set; }

	[Position(04)]
	public string DepositorOrderNumber { get; set; }

	[Position(05)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(06)]
	public string TimeQualifier { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public string MasterReferenceLinkNumber { get; set; }

	[Position(09)]
	public int? LinkSequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W17_WarehouseReceiptIdentification>(this);
		validator.Required(x=>x.ReportingCode);
		validator.Required(x=>x.DateOfReceipt);
		validator.Required(x=>x.WarehouseReceiptNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TimeQualifier, x=>x.Time);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MasterReferenceLinkNumber, x=>x.LinkSequenceNumber);
		validator.Length(x => x.ReportingCode, 1);
		validator.Length(x => x.DateOfReceipt, 6);
		validator.Length(x => x.WarehouseReceiptNumber, 1, 12);
		validator.Length(x => x.DepositorOrderNumber, 1, 22);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.TimeQualifier, 1);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.MasterReferenceLinkNumber, 1, 22);
		validator.Length(x => x.LinkSequenceNumber, 6);
		return validator.Results;
	}
}
