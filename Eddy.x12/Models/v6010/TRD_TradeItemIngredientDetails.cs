using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("TRD")]
public class TRD_TradeItemIngredientDetails : EdiX12Segment
{
	[Position(01)]
	public string MeasurementQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public decimal? MeasurementValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRD_TradeItemIngredientDetails>(this);
		validator.Required(x=>x.MeasurementQualifier);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.MeasurementValue);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.MeasurementValue, 1, 20);
		return validator.Results;
	}
}
