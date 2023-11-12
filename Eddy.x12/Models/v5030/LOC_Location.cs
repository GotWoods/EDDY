using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030.Composites;

namespace Eddy.x12.Models.v5030;

[Segment("LOC")]
public class LOC_Location : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

	[Position(05)]
	public string Category { get; set; }

	[Position(06)]
	public string ReferenceIdentificationQualifier2 { get; set; }

	[Position(07)]
	public string ReferenceIdentification3 { get; set; }

	[Position(08)]
	public string Description2 { get; set; }

	[Position(09)]
	public string ReferenceIdentification4 { get; set; }

	[Position(10)]
	public decimal? MeasurementValue { get; set; }

	[Position(11)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(12)]
	public decimal? MeasurementValue2 { get; set; }

	[Position(13)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure2 { get; set; }

	[Position(14)]
	public decimal? MeasurementValue3 { get; set; }

	[Position(15)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure3 { get; set; }

	[Position(16)]
	public decimal? MeasurementValue4 { get; set; }

	[Position(17)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure4 { get; set; }

	[Position(18)]
	public decimal? MeasurementValue5 { get; set; }

	[Position(19)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure5 { get; set; }

	[Position(20)]
	public decimal? MeasurementValue6 { get; set; }

	[Position(21)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure6 { get; set; }

	[Position(22)]
	public string ReferenceIdentificationQualifier3 { get; set; }

	[Position(23)]
	public string ReferenceIdentification5 { get; set; }

	[Position(24)]
	public string Description3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LOC_Location>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier2, x=>x.ReferenceIdentification3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier3, x=>x.ReferenceIdentification5);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.Category, 1, 6);
		validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.ReferenceIdentification4, 1, 80);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.MeasurementValue2, 1, 20);
		validator.Length(x => x.MeasurementValue3, 1, 20);
		validator.Length(x => x.MeasurementValue4, 1, 20);
		validator.Length(x => x.MeasurementValue5, 1, 20);
		validator.Length(x => x.MeasurementValue6, 1, 20);
		validator.Length(x => x.ReferenceIdentificationQualifier3, 2, 3);
		validator.Length(x => x.ReferenceIdentification5, 1, 80);
		validator.Length(x => x.Description3, 1, 80);
		return validator.Results;
	}
}
