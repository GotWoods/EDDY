using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("P1")]
public class P1_Pickup : EdiX12Segment
{
	[Position(01)]
	public string PickupOrDeliveryCode { get; set; }

	[Position(02)]
	public string PickupDate { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	[Position(04)]
	public string PickupTime { get; set; }

	[Position(05)]
	public string EquipmentInitial { get; set; }

	[Position(06)]
	public string EquipmentNumber { get; set; }

	[Position(07)]
	public int? NumberOfShipments { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<P1_Pickup>(this);
		validator.Required(x=>x.PickupDate);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Length(x => x.PickupOrDeliveryCode, 1, 2);
		validator.Length(x => x.PickupDate, 8);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.PickupTime, 4);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.NumberOfShipments, 1, 5);
		return validator.Results;
	}
}
