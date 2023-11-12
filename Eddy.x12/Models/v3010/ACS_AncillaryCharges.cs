using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ACS")]
public class ACS_AncillaryCharges : EdiX12Segment
{
	[Position(01)]
	public string Charge { get; set; }

	[Position(02)]
	public string SpecialChargeCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ACS_AncillaryCharges>(this);
		validator.Required(x=>x.Charge);
		validator.Required(x=>x.SpecialChargeCode);
		validator.Length(x => x.Charge, 1, 9);
		validator.Length(x => x.SpecialChargeCode, 3);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
