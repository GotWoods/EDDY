using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("RES")]
public class RES_Resource : EdiX12Segment
{
	[Position(01)]
	public string ResourceCodeOrIdentifier { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string ResourceType { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string ReferenceIdentification2 { get; set; }

	[Position(06)]
	public string QuantityQualifier { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(09)]
	public string QuantityQualifier2 { get; set; }

	[Position(10)]
	public decimal? Quantity2 { get; set; }

	[Position(11)]
	public string AmountQualifierCode { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount { get; set; }

	[Position(13)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure2 { get; set; }

	[Position(14)]
	public string RateValueQualifier { get; set; }

	[Position(15)]
	public decimal? Rate { get; set; }

	[Position(16)]
	public string PercentQualifier { get; set; }

	[Position(17)]
	public decimal? Percent { get; set; }

	[Position(18)]
	public string DateTimeQualifier { get; set; }

	[Position(19)]
	public string Date { get; set; }

	[Position(20)]
	public string DateTimeQualifier2 { get; set; }

	[Position(21)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RES_Resource>(this);
		validator.Required(x=>x.ResourceCodeOrIdentifier);
		validator.ARequiresB(x=>x.QuantityQualifier2, x=>x.Quantity2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier, x=>x.Rate);
		validator.Length(x => x.ResourceCodeOrIdentifier, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ResourceType, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.QuantityQualifier2, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.PercentQualifier, 1, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 6);
		return validator.Results;
	}
}
