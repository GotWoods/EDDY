using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("GR5")]
public class GR5_LoadingDetails : EdiX12Segment
{
	[Position(01)]
	public string SpecialHandlingCode { get; set; }

	[Position(02)]
	public string SurfaceLayerPositionCode { get; set; }

	[Position(03)]
	public decimal? MeasurementValue { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GR5_LoadingDetails>(this);
		validator.Required(x=>x.SpecialHandlingCode);
		validator.AtLeastOneIsRequired(x=>x.SurfaceLayerPositionCode, x=>x.MeasurementValue);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		validator.Length(x => x.MeasurementValue, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
