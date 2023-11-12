using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("TLN")]
public class TLN_Tradeline : EdiX12Segment
{
	[Position(01)]
	public string AccountNumber { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(04)]
	public string TypeOfAccountCode { get; set; }

	[Position(05)]
	public string TypeOfAccountCode2 { get; set; }

	[Position(06)]
	public string TypeOfCreditAccountCode { get; set; }

	[Position(07)]
	public int? Number { get; set; }

	[Position(08)]
	public string LoanTypeCode { get; set; }

	[Position(09)]
	public string RatingCode { get; set; }

	[Position(10)]
	public string RatingRemarksCode { get; set; }

	[Position(11)]
	public string SourceOfDisclosureCode { get; set; }

	[Position(12)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(13)]
	public string DateTimePeriod { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount { get; set; }

	[Position(15)]
	public string RatingCode2 { get; set; }

	[Position(16)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(17)]
	public string DateTimePeriod2 { get; set; }

	[Position(18)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(19)]
	public string RatingCode3 { get; set; }

	[Position(20)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(21)]
	public int? Number2 { get; set; }

	[Position(22)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TLN_Tradeline>(this);
		validator.Required(x=>x.AccountNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.TypeOfAccountCode, 2);
		validator.Length(x => x.TypeOfAccountCode2, 2);
		validator.Length(x => x.TypeOfCreditAccountCode, 1);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.LoanTypeCode, 1, 2);
		validator.Length(x => x.RatingCode, 2);
		validator.Length(x => x.RatingRemarksCode, 2);
		validator.Length(x => x.SourceOfDisclosureCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.RatingCode2, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.RatingCode3, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.Number2, 1, 9);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
