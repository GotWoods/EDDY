using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Models.v7060;

[Segment("TRT")]
public class TRT_TradeItemType : EdiX12Segment
{
	[Position(01)]
	public string ClassOfTradeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public C068_CompositeIngredientInformation CompositeIngredientInformation { get; set; }

	[Position(05)]
	public string ReferenceIdentificationQualifier2 { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public decimal? MeasurementValue { get; set; }

	[Position(08)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRT_TradeItemType>(this);
		validator.Required(x=>x.ClassOfTradeCode);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.CompositeIngredientInformation);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier2, x=>x.ReferenceIdentification2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue, x=>x.CompositeUnitOfMeasure);
		validator.Length(x => x.ClassOfTradeCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.MeasurementValue, 1, 20);
		return validator.Results;
	}
}
