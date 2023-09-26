using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("RT1")]
public class RT1_RateDetail : EdiX12Segment
{
	[Position(01)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(02)]
	public string VehicleTypeCode { get; set; }

	[Position(03)]
	public decimal? FreightRate { get; set; }

	[Position(04)]
	public string RoundingRuleCode { get; set; }

	[Position(05)]
	public string VehicleIdentificationNumberVINPlantCode { get; set; }

	[Position(06)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(07)]
	public string TariffItemNumber { get; set; }

	[Position(08)]
	public string SpecialRateCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RT1_RateDetail>(this);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Required(x=>x.VehicleTypeCode);
		validator.Required(x=>x.FreightRate);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.VehicleTypeCode, 1);
		validator.Length(x => x.FreightRate, 1, 9);
		validator.Length(x => x.RoundingRuleCode, 1);
		validator.Length(x => x.VehicleIdentificationNumberVINPlantCode, 1);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.TariffItemNumber, 1, 16);
		validator.Length(x => x.SpecialRateCode, 1, 2);
		return validator.Results;
	}
}
