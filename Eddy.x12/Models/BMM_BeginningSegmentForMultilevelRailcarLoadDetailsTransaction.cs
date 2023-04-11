using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BMM")]
public class BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string StandardPointLocationCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public int? WaybillNumber { get; set; }

	[Position(05)]
	public string StandardPointLocationCode2 { get; set; }

	[Position(06)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(07)]
	public string VehicleStatus { get; set; }

	[Position(08)]
	public string AccountNumber { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string TransactionSetPurposeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.WaybillNumber);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.VehicleStatus, 1, 2);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		return validator.Results;
	}
}
