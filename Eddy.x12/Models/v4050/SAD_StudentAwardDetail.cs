using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("SAD")]
public class SAD_StudentAwardDetail : EdiX12Segment
{
	[Position(01)]
	public string StatusReasonCode { get; set; }

	[Position(02)]
	public decimal? InterestRate { get; set; }

	[Position(03)]
	public string LoanRateTypeCode { get; set; }

	[Position(04)]
	public string PaymentMethodTypeCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string CodeListQualifierCode { get; set; }

	[Position(07)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SAD_StudentAwardDetail>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.LoanRateTypeCode, 1);
		validator.Length(x => x.PaymentMethodTypeCode, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}
