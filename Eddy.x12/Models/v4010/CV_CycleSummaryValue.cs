using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("CV")]
public class CV_CycleSummaryValue : EdiX12Segment
{
	[Position(01)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(02)]
	public string PaymentActionCode { get; set; }

	[Position(03)]
	public string CarTypeGroupCode { get; set; }

	[Position(04)]
	public string TimePeriodQualifier { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string MileageSettlementCode { get; set; }

	[Position(07)]
	public decimal? Quantity2 { get; set; }

	[Position(08)]
	public decimal? Quantity3 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount { get; set; }

	[Position(10)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(13)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(14)]
	public string PenaltyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CV_CycleSummaryValue>(this);
		validator.Required(x=>x.LoadEmptyStatusCode);
		validator.ARequiresB(x=>x.Quantity, x=>x.TimePeriodQualifier);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.PaymentActionCode, 2);
		validator.Length(x => x.CarTypeGroupCode, 1);
		validator.Length(x => x.TimePeriodQualifier, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MileageSettlementCode, 1);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.MonetaryAmount4, 1, 18);
		validator.Length(x => x.MonetaryAmount5, 1, 18);
		validator.Length(x => x.PenaltyCode, 1);
		return validator.Results;
	}
}
