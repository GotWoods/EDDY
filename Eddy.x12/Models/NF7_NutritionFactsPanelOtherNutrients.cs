using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("NF7")]
public class NF7_NutritionFactsPanelOtherNutrients : EdiX12Segment
{
	[Position(01)]
	public string MeasurementQualifier { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string MeasurementSignificanceCode { get; set; }

	[Position(05)]
	public decimal? MeasurementValue2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NF7_NutritionFactsPanelOtherNutrients>(this);
		validator.Required(x=>x.MeasurementQualifier);
		validator.Required(x=>x.MeasurementValue);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.MeasurementSignificanceCode, 2);
		validator.Length(x => x.MeasurementValue2, 1, 20);
		return validator.Results;
	}
}
