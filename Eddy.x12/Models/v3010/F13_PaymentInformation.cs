using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("F13")]
public class F13_PaymentInformation : EdiX12Segment
{
	[Position(01)]
	public string CheckNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public long? MICRNumber { get; set; }

	[Position(05)]
	public string Date3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F13_PaymentInformation>(this);
		validator.Required(x=>x.CheckNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.Length(x => x.CheckNumber, 1, 16);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.MICRNumber, 16);
		validator.Length(x => x.Date3, 6);
		return validator.Results;
	}
}
