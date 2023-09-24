using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("VID")]
public class VID_VehicleID : EdiX12Segment
{
	[Position(01)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string SealNumber { get; set; }

	[Position(05)]
	public string SealNumber2 { get; set; }

	[Position(06)]
	public int? EquipmentLength { get; set; }

	[Position(07)]
	public decimal? Height { get; set; }

	[Position(08)]
	public decimal? Width { get; set; }

	[Position(09)]
	public string EquipmentType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VID_VehicleID>(this);
		validator.Required(x=>x.EquipmentDescriptionCode);
		validator.Required(x=>x.EquipmentNumber);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.SealNumber2, 2, 15);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.EquipmentType, 4);
		return validator.Results;
	}
}
