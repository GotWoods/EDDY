using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("FAA")]
public class FAA_FinancialAssetAccount : EdiX12Segment
{
	[Position(01)]
	public string AccountNumberQualifier { get; set; }

	[Position(02)]
	public string AccountNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string TypeOfAccountCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public string DateTimeQualifier { get; set; }

	[Position(10)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(11)]
	public string DateTimePeriod { get; set; }

	[Position(12)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(13)]
	public string ReferenceIdentification { get; set; }

	[Position(14)]
	public string ReferenceIdentification2 { get; set; }

	[Position(15)]
	public string MaintenanceTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FAA_FinancialAssetAccount>(this);
		validator.Required(x=>x.AccountNumberQualifier);
		validator.ARequiresB(x=>x.DateTimeQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.AccountNumberQualifier, 1, 3);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.TypeOfAccountCode, 2);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		return validator.Results;
	}
}
