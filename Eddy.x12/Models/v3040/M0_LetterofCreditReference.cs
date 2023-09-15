using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("M0")]
public class M0_LetterOfCreditReference : EdiX12Segment
{
	[Position(01)]
	public string LetterOfCreditNumber { get; set; }

	[Position(02)]
	public string LetterOfCreditDate { get; set; }

	[Position(03)]
	public string LetterOfCreditExpirationDate { get; set; }

	[Position(04)]
	public string OnBoardVesselDate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M0_LetterOfCreditReference>(this);
		validator.Required(x=>x.LetterOfCreditNumber);
		validator.Length(x => x.LetterOfCreditNumber, 2, 24);
		validator.Length(x => x.LetterOfCreditDate, 6);
		validator.Length(x => x.LetterOfCreditExpirationDate, 6);
		validator.Length(x => x.OnBoardVesselDate, 6);
		return validator.Results;
	}
}
