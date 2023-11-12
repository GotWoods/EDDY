using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Models.v7060;

[Segment("NF2")]
public class NF2_ServingSizeStatement : EdiX12Segment
{
	[Position(01)]
	public C071_CompositeMultipleLanguageTextInformation CompositeMultipleLanguageTextInformation { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string MeasurementSignificanceCode { get; set; }

	[Position(05)]
	public decimal? MeasurementValue2 { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(07)]
	public string MeasurementSignificanceCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NF2_ServingSizeStatement>(this);
		validator.Required(x=>x.CompositeMultipleLanguageTextInformation);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue2, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.MeasurementSignificanceCode, 2);
		validator.Length(x => x.MeasurementValue2, 1, 20);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.MeasurementSignificanceCode2, 2);
		return validator.Results;
	}
}
