using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060;

[Segment("NF4")]
public class NF4_NutritionFactsPanelCalorie : EdiX12Segment
{
	[Position(01)]
	public string MeasurementQualifier { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NF4_NutritionFactsPanelCalorie>(this);
		validator.Required(x=>x.MeasurementQualifier);
		validator.Required(x=>x.MeasurementValue);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
