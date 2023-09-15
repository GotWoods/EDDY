using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("L9")]
public class L9_ChargeDetail : EdiX12Segment
{
	[Position(01)]
	public string SpecialChargeCode { get; set; }

	[Position(02)]
	public decimal? SpecialCharge { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L9_ChargeDetail>(this);
		validator.Required(x=>x.SpecialChargeCode);
		validator.Required(x=>x.SpecialCharge);
		validator.Length(x => x.SpecialChargeCode, 3);
		validator.Length(x => x.SpecialCharge, 1, 7);
		return validator.Results;
	}
}
