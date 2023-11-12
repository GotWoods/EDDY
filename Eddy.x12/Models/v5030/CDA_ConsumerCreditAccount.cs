using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("CDA")]
public class CDA_ConsumerCreditAccount : EdiX12Segment
{
	[Position(01)]
	public string AccountNumber { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(06)]
	public string TypeOfAccountCode { get; set; }

	[Position(07)]
	public string TypeOfCreditAccountCode { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public decimal? Quantity2 { get; set; }

	[Position(10)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(11)]
	public string DateTimePeriod { get; set; }

	[Position(12)]
	public string DateTimePeriod2 { get; set; }

	[Position(13)]
	public string DateTimePeriod3 { get; set; }

	[Position(14)]
	public string DateTimePeriod4 { get; set; }

	[Position(15)]
	public string DateTimePeriod5 { get; set; }

	[Position(16)]
	public string Description { get; set; }

	[Position(17)]
	public string ReferenceIdentification { get; set; }

	[Position(18)]
	public string LoanTypeCode { get; set; }

	[Position(19)]
	public string FrequencyCode { get; set; }

	[Position(20)]
	public string ReferenceIdentification2 { get; set; }

	[Position(21)]
	public string MaintenanceTypeCode { get; set; }

	[Position(22)]
	public string StatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDA_ConsumerCreditAccount>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod, x=>x.DateTimePeriod2, x=>x.DateTimePeriod3, x=>x.DateTimePeriod4, x=>x.DateTimePeriod5);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod2, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod3, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod4, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod5, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.FrequencyCode, x=>x.MonetaryAmount4);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.MonetaryAmount4, 1, 18);
		validator.Length(x => x.TypeOfAccountCode, 2);
		validator.Length(x => x.TypeOfCreditAccountCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.DateTimePeriod4, 1, 35);
		validator.Length(x => x.DateTimePeriod5, 1, 35);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.LoanTypeCode, 1, 2);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.StatusCode, 2);
		return validator.Results;
	}
}
