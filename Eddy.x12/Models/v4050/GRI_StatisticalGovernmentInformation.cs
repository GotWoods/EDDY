using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("GRI")]
public class GRI_StatisticalGovernmentInformation : EdiX12Segment
{
	[Position(01)]
	public string ReportedDataIDCode { get; set; }

	[Position(02)]
	public string ReportedDataResponse { get; set; }

	[Position(03)]
	public string QuantityQualifier { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string AmountQualifierCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount { get; set; }

	[Position(07)]
	public string PercentQualifier { get; set; }

	[Position(08)]
	public int? PercentIntegerFormat { get; set; }

	[Position(09)]
	public string DateTimeQualifier { get; set; }

	[Position(10)]
	public string Date { get; set; }

	[Position(11)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GRI_StatisticalGovernmentInformation>(this);
		validator.Required(x=>x.ReportedDataIDCode);
		validator.ARequiresB(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.ARequiresB(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.ARequiresB(x=>x.PercentQualifier, x=>x.PercentIntegerFormat);
		validator.ARequiresB(x=>x.DateTimeQualifier, x=>x.Date);
		validator.Length(x => x.ReportedDataIDCode, 1, 6);
		validator.Length(x => x.ReportedDataResponse, 1, 10);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentQualifier, 1, 2);
		validator.Length(x => x.PercentIntegerFormat, 1, 3);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
