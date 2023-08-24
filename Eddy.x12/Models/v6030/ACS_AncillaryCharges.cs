using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("ACS")]
public class ACS_AncillaryCharges : EdiX12Segment
{
	[Position(01)]
	public string Amount { get; set; }

	[Position(02)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ACS_AncillaryCharges>(this);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.SpecialChargeOrAllowanceCode);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		return validator.Results;
	}
}
