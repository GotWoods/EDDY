using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

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
	public string TypeOfAccount { get; set; }

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDA_ConsumerCreditAccount>(this);
		validator.Required(x=>x.AccountNumber);
		validator.Required(x=>x.MonetaryAmount);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod2, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod3, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod4, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod5, x=>x.DateTimePeriodFormatQualifier);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.TypeOfAccount, 2);
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
		return validator.Results;
	}
}
