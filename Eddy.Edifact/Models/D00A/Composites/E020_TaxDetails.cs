using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E020")]
public class E020_TaxDetails : EdifactComponent
{
	[Position(1)]
	public string DutyOrTaxOrFeeTypeNameCode { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string DutyOrTaxOrFeeRateDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E020_TaxDetails>(this);
		validator.Required(x=>x.DutyOrTaxOrFeeTypeNameCode);
		validator.Length(x => x.DutyOrTaxOrFeeTypeNameCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.DutyOrTaxOrFeeRateDescription, 1, 17);
		return validator.Results;
	}
}
