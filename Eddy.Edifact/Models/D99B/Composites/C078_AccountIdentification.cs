using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C078")]
public class C078_AccountHolderIdentification : EdifactComponent
{
	[Position(1)]
	public string AccountHolderNumber { get; set; }

	[Position(2)]
	public string AccountHolderName { get; set; }

	[Position(3)]
	public string AccountHolderName2 { get; set; }

	[Position(4)]
	public string CurrencyIdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C078_AccountHolderIdentification>(this);
		validator.Length(x => x.AccountHolderNumber, 1, 35);
		validator.Length(x => x.AccountHolderName, 1, 35);
		validator.Length(x => x.AccountHolderName2, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		return validator.Results;
	}
}
