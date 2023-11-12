using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("PLD")]
public class PLD_PalletInformation : EdiX12Segment
{
	[Position(01)]
	public int? QuantityOfPalletsShipped { get; set; }

	[Position(02)]
	public string PalletExchangeCode { get; set; }

	[Position(03)]
	public string WeightUnitCode { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PLD_PalletInformation>(this);
		validator.Required(x=>x.QuantityOfPalletsShipped);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.Weight);
		validator.Length(x => x.QuantityOfPalletsShipped, 1, 3);
		validator.Length(x => x.PalletExchangeCode, 1);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		return validator.Results;
	}
}
