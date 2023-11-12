using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("F11")]
public class F11_Status : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ReferenceNumber2 { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string Amount2 { get; set; }

	[Position(06)]
	public string StatusCode { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string DeclineAmendReasonCode { get; set; }

	[Position(09)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F11_Status>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.ReferenceNumber2);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.StatusCode);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.CurrencyCode);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.DeclineAmendReasonCode, 3);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
