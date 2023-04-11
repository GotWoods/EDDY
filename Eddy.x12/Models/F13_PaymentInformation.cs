using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("F13")]
public class F13_PaymentInformation : EdiX12Segment
{
	[Position(01)]
	public string CheckNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Amount { get; set; }

	[Position(04)]
	public string MICRNumber { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F13_PaymentInformation>(this);
		validator.Required(x=>x.CheckNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.CurrencyCode);
		validator.Length(x => x.CheckNumber, 1, 16);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.MICRNumber, 16);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
