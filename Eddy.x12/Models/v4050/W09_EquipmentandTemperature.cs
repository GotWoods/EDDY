using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("W09")]
public class W09_EquipmentAndTemperature : EdiX12Segment
{
	[Position(01)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(02)]
	public decimal? Temperature { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Temperature2 { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(06)]
	public string FreeFormMessage { get; set; }

	[Position(07)]
	public string VentSettingCode { get; set; }

	[Position(08)]
	public int? PercentIntegerFormat { get; set; }

	[Position(09)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W09_EquipmentAndTemperature>(this);
		validator.Required(x=>x.EquipmentDescriptionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Temperature, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Temperature2, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.Temperature, 1, 4);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Temperature2, 1, 4);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.VentSettingCode, 1);
		validator.Length(x => x.PercentIntegerFormat, 1, 3);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
