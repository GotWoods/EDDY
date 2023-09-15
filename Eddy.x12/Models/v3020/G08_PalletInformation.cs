using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("G08")]
public class G08_PalletInformation : EdiX12Segment
{
	[Position(01)]
	public int? QuantityOfPalletsReceived { get; set; }

	[Position(02)]
	public int? QuantityOfPalletsReturned { get; set; }

	[Position(03)]
	public decimal? QuantityContested { get; set; }

	[Position(04)]
	public string ReceivingConditionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G08_PalletInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityContested, x=>x.ReceivingConditionCode);
		validator.Length(x => x.QuantityOfPalletsReceived, 1, 3);
		validator.Length(x => x.QuantityOfPalletsReturned, 1, 3);
		validator.Length(x => x.QuantityContested, 1, 7);
		validator.Length(x => x.ReceivingConditionCode, 2);
		return validator.Results;
	}
}
