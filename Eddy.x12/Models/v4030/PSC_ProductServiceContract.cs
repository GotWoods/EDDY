using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030.Composites;

namespace Eddy.x12.Models.v4030;

[Segment("PSC")]
public class PSC_ProductServiceContract : EdiX12Segment
{
	[Position(01)]
	public string ContractStatusCode { get; set; }

	[Position(02)]
	public string TypeOfProductServiceCode { get; set; }

	[Position(03)]
	public string TypeOfProductServiceCode2 { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string EntityIdentifierCode { get; set; }

	[Position(06)]
	public string ContractNumber { get; set; }

	[Position(07)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(08)]
	public int? Count { get; set; }

	[Position(09)]
	public string DateTimeQualifier { get; set; }

	[Position(10)]
	public string Date { get; set; }

	[Position(11)]
	public string Date2 { get; set; }

	[Position(12)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure2 { get; set; }

	[Position(13)]
	public decimal? RangeMaximum { get; set; }

	[Position(14)]
	public decimal? RangeMinimum { get; set; }

	[Position(15)]
	public decimal? MeasurementValue { get; set; }

	[Position(16)]
	public string ActionCode { get; set; }

	[Position(17)]
	public decimal? Percent { get; set; }

	[Position(18)]
	public string AgencyQualifierCode { get; set; }

	[Position(19)]
	public string SourceSubqualifier { get; set; }

	[Position(20)]
	public string OperationEnvironmentCode { get; set; }

	[Position(21)]
	public string SpecialServicesCode { get; set; }

	[Position(22)]
	public string Description { get; set; }

	[Position(23)]
	public decimal? UnitPrice { get; set; }

	[Position(24)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(25)]
	public string ContactMethodCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PSC_ProductServiceContract>(this);
		validator.Required(x=>x.ContractStatusCode);
		validator.Required(x=>x.TypeOfProductServiceCode);
		validator.ARequiresB(x=>x.RangeMaximum, x=>x.CompositeUnitOfMeasure2);
		validator.ARequiresB(x=>x.RangeMinimum, x=>x.CompositeUnitOfMeasure2);
		validator.ARequiresB(x=>x.MeasurementValue, x=>x.CompositeUnitOfMeasure2);
		validator.ARequiresB(x=>x.ActionCode, x=>x.RangeMaximum);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ActionCode, x=>x.Count, x=>x.Date);
		validator.ARequiresB(x=>x.AgencyQualifierCode, x=>x.OperationEnvironmentCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.Length(x => x.ContractStatusCode, 2);
		validator.Length(x => x.TypeOfProductServiceCode, 2, 4);
		validator.Length(x => x.TypeOfProductServiceCode2, 2, 4);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.RangeMaximum, 1, 20);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.OperationEnvironmentCode, 2, 3);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ContactMethodCode, 1);
		return validator.Results;
	}
}
