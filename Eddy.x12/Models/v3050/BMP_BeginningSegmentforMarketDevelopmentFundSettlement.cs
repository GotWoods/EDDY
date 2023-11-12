using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("BMP")]
public class BMP_BeginningSegmentForMarketDevelopmentFundSettlement : EdiX12Segment
{
	[Position(01)]
	public string TransactionHandlingCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string PaymentMethodCode { get; set; }

	[Position(04)]
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BMP_BeginningSegmentForMarketDevelopmentFundSettlement>(this);
		validator.Required(x=>x.TransactionHandlingCode);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.TransactionHandlingCode, 1, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}
