using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BMP")]
public class BMP_BeginningSegmentForMarketDevelopmentFundSettlement : EdiX12Segment
{
	[Position(01)]
	public string TransactionHandlingCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string PaymentMethodCode { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BMP_BeginningSegmentForMarketDevelopmentFundSettlement>(this);
		validator.Required(x=>x.TransactionHandlingCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.TransactionHandlingCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		return validator.Results;
	}
}
