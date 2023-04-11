using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("NF3")]
public class NF3_ServingsPerContainerStatement : EdiX12Segment
{
	[Position(01)]
	public C071_CompositeMultipleLanguageTextInformation CompositeMultipleLanguageTextInformation { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string MeasurementSignificanceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NF3_ServingsPerContainerStatement>(this);
		validator.Required(x=>x.CompositeMultipleLanguageTextInformation);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.MeasurementSignificanceCode, 2);
		return validator.Results;
	}
}
