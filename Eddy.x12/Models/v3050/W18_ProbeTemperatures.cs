using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("W18")]
public class W18_ProbeTemperatures : EdiX12Segment
{
	[Position(01)]
	public string TemperatureProbeLocationCode { get; set; }

	[Position(02)]
	public decimal? Temperature { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W18_ProbeTemperatures>(this);
		validator.Required(x=>x.TemperatureProbeLocationCode);
		validator.Required(x=>x.Temperature);
		validator.Length(x => x.TemperatureProbeLocationCode, 2);
		validator.Length(x => x.Temperature, 1, 4);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
