using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("R2D")]
public class R2D_MiscellaneousCharge : EdiX12Segment
{
	[Position(01)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(02)]
	public string Amount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R2D_MiscellaneousCharge>(this);
		validator.Required(x=>x.SpecialChargeOrAllowanceCode);
		validator.Required(x=>x.Amount);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.Amount, 1, 9);
		return validator.Results;
	}
}
