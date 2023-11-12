using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("LN")]
public class LN_LoanInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string FrequencyCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public decimal? Percent { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string LoanPurposeCode { get; set; }

	[Position(10)]
	public string LoanPaymentTypeCode { get; set; }

	[Position(11)]
	public string LoanRateTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LN_LoanInformation>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FrequencyCode, x=>x.MonetaryAmount2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.LoanPurposeCode, 2);
		validator.Length(x => x.LoanPaymentTypeCode, 2);
		validator.Length(x => x.LoanRateTypeCode, 1);
		return validator.Results;
	}
}
