using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("BNX")]
public class BNX_RailShipmentInformation : EdiX12Segment
{
	[Position(01)]
	public string ShipmentWeightCode { get; set; }

	[Position(02)]
	public string ReferencedPatternIdentifier { get; set; }

	[Position(03)]
	public string BillingCode { get; set; }

	[Position(04)]
	public int? RepetitivePatternNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BNX_RailShipmentInformation>(this);
		validator.Length(x => x.ShipmentWeightCode, 1);
		validator.Length(x => x.ReferencedPatternIdentifier, 1, 13);
		validator.Length(x => x.BillingCode, 1);
		validator.Length(x => x.RepetitivePatternNumber, 5);
		return validator.Results;
	}
}
