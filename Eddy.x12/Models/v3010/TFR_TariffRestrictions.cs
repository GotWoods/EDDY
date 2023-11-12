using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TFR")]
public class TFR_TariffRestrictions : EdiX12Segment
{
	[Position(01)]
	public string TariffRestrictionIDCode { get; set; }

	[Position(02)]
	public string TariffRestrictionDescription { get; set; }

	[Position(03)]
	public decimal? TariffRestrictionValue { get; set; }

	[Position(04)]
	public decimal? TariffRestrictionValue2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TFR_TariffRestrictions>(this);
		validator.Required(x=>x.TariffRestrictionIDCode);
		validator.Length(x => x.TariffRestrictionIDCode, 1, 2);
		validator.Length(x => x.TariffRestrictionDescription, 1, 10);
		validator.Length(x => x.TariffRestrictionValue, 1, 9);
		validator.Length(x => x.TariffRestrictionValue2, 1, 9);
		return validator.Results;
	}
}
