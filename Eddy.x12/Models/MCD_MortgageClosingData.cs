using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("MCD")]
public class MCD_MortgageClosingData : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(04)]
	public string Name { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MCD_MortgageClosingData>(this);
		validator.ARequiresB(x=>x.Name, x=>x.MonetaryAmount2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.Name, 1, 60);
		return validator.Results;
	}
}
