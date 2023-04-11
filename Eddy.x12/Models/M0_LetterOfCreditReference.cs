using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("M0")]
public class M0_LetterOfCreditReference : EdiX12Segment
{
	[Position(01)]
	public string LetterOfCreditNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public string Date3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M0_LetterOfCreditReference>(this);
		validator.Required(x=>x.LetterOfCreditNumber);
		validator.Length(x => x.LetterOfCreditNumber, 2, 40);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Date3, 8);
		return validator.Results;
	}
}
