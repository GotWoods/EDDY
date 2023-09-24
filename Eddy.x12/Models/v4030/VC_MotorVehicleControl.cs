using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("VC")]
public class VC_MotorVehicleControl : EdiX12Segment
{
	[Position(01)]
	public string VehicleIdentificationNumber { get; set; }

	[Position(02)]
	public string VehicleDeckPositionCode { get; set; }

	[Position(03)]
	public string VehicleTypeCode { get; set; }

	[Position(04)]
	public string DealerCode { get; set; }

	[Position(05)]
	public string RouteCode { get; set; }

	[Position(06)]
	public string BayLocation { get; set; }

	[Position(07)]
	public string AutomotiveManufacturersCode { get; set; }

	[Position(08)]
	public string DamageExceptionIndicator { get; set; }

	[Position(09)]
	public string SupplementalInspectionCode { get; set; }

	[Position(10)]
	public string FactoryCarOrderNumber { get; set; }

	[Position(11)]
	public string VesselStowageLocation { get; set; }

	[Position(12)]
	public string EquipmentOrientationCode { get; set; }

	[Position(13)]
	public string LocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VC_MotorVehicleControl>(this);
		validator.Required(x=>x.VehicleIdentificationNumber);
		validator.Length(x => x.VehicleIdentificationNumber, 1, 25);
		validator.Length(x => x.VehicleDeckPositionCode, 2);
		validator.Length(x => x.VehicleTypeCode, 1);
		validator.Length(x => x.DealerCode, 2, 9);
		validator.Length(x => x.RouteCode, 1, 13);
		validator.Length(x => x.BayLocation, 1, 6);
		validator.Length(x => x.AutomotiveManufacturersCode, 2);
		validator.Length(x => x.DamageExceptionIndicator, 1);
		validator.Length(x => x.SupplementalInspectionCode, 1);
		validator.Length(x => x.FactoryCarOrderNumber, 6, 10);
		validator.Length(x => x.VesselStowageLocation, 1, 12);
		validator.Length(x => x.EquipmentOrientationCode, 1);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		return validator.Results;
	}
}
