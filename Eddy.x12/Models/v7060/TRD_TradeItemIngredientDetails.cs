using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Models.v7060;

[Segment("TRD")]
public class TRD_TradeItemIngredientDetails : EdiX12Segment
{
	[Position(01)]
	public string MeasurementQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public C068_CompositeIngredientInformation CompositeIngredientInformation { get; set; }

	[Position(04)]
	public decimal? MeasurementValue { get; set; }

	[Position(05)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(06)]
	public string PrecursorStatus { get; set; }

	[Position(07)]
	public string AgencyQualifierCode { get; set; }

	[Position(08)]
	public string ProductDescriptionCode { get; set; }

	[Position(09)]
	public decimal? MeasurementValue2 { get; set; }

	[Position(10)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure2 { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(12)]
	public decimal? MeasurementValue3 { get; set; }

	[Position(13)]
	public string ControlledDrug { get; set; }

	[Position(14)]
	public decimal? MeasurementValue4 { get; set; }

	[Position(15)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure3 { get; set; }

	[Position(16)]
	public string Narcotic { get; set; }

	[Position(17)]
	public decimal? MeasurementValue5 { get; set; }

	[Position(18)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRD_TradeItemIngredientDetails>(this);
		validator.Required(x=>x.MeasurementQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue4, x=>x.CompositeUnitOfMeasure3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue5, x=>x.CompositeUnitOfMeasure4);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.PrecursorStatus, 2);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.MeasurementValue2, 1, 20);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.MeasurementValue3, 1, 20);
		validator.Length(x => x.ControlledDrug, 4);
		validator.Length(x => x.MeasurementValue4, 1, 20);
		validator.Length(x => x.Narcotic, 4);
		validator.Length(x => x.MeasurementValue5, 1, 20);
		return validator.Results;
	}
}
