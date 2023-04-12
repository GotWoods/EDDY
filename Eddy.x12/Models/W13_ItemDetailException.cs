using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("W13")]
public class W13_ItemDetailException : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public string ReceivingConditionCode { get; set; }

	[Position(04)]
	public string WarehouseLotNumber { get; set; }

	[Position(05)]
	public string DamageReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W13_ItemDetailException>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.ReceivingConditionCode);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.ReceivingConditionCode, 2);
		validator.Length(x => x.WarehouseLotNumber, 1, 12);
		validator.Length(x => x.DamageReasonCode, 2);
		return validator.Results;
	}
}
