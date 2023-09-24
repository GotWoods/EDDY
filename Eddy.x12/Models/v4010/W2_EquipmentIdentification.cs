using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("W2")]
public class W2_EquipmentIdentification : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	[Position(04)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(05)]
	public string EquipmentStatusCode { get; set; }

	[Position(06)]
	public int? NetTons { get; set; }

	[Position(07)]
	public string IntermodalServiceCode { get; set; }

	[Position(08)]
	public string CarServiceOrderCode { get; set; }

	[Position(09)]
	public string Date { get; set; }

	[Position(10)]
	public string TypeOfLocomotiveMaintenanceCode { get; set; }

	[Position(11)]
	public string EquipmentInitial2 { get; set; }

	[Position(12)]
	public string EquipmentNumber2 { get; set; }

	[Position(13)]
	public int? EquipmentNumberCheckDigit { get; set; }

	[Position(14)]
	public string Position { get; set; }

	[Position(15)]
	public string CarTypeCode { get; set; }

	[Position(16)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W2_EquipmentIdentification>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.EquipmentDescriptionCode);
		validator.Required(x=>x.EquipmentStatusCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Date, x=>x.TypeOfLocomotiveMaintenanceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EquipmentInitial2, x=>x.EquipmentNumber2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentStatusCode, 1, 2);
		validator.Length(x => x.NetTons, 1, 3);
		validator.Length(x => x.IntermodalServiceCode, 1, 2);
		validator.Length(x => x.CarServiceOrderCode, 3, 5);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.TypeOfLocomotiveMaintenanceCode, 2);
		validator.Length(x => x.EquipmentInitial2, 1, 4);
		validator.Length(x => x.EquipmentNumber2, 1, 10);
		validator.Length(x => x.EquipmentNumberCheckDigit, 1);
		validator.Length(x => x.Position, 1, 3);
		validator.Length(x => x.CarTypeCode, 1, 4);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
