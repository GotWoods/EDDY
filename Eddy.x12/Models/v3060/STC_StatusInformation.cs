using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("STC")]
public class STC_StatusInformation : EdiX12Segment
{
	[Position(01)]
	public string IndustryCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string ActionCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public string PaymentMethodCode { get; set; }

	[Position(08)]
	public string Date3 { get; set; }

	[Position(09)]
	public string CheckNumber { get; set; }

	[Position(10)]
	public string IndustryCode2 { get; set; }

	[Position(11)]
	public string IndustryCode3 { get; set; }

	[Position(12)]
	public string FreeFormMessageText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STC_StatusInformation>(this);
		validator.Required(x=>x.IndustryCode);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.Date3, 6);
		validator.Length(x => x.CheckNumber, 1, 16);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.IndustryCode3, 1, 30);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		return validator.Results;
	}
}
