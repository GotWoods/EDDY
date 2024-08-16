using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E020")]
public class E020_TaxDetails : EdifactComponent
{
	[Position(1)]
	public string DutyTaxFeeTypeNameCode { get; set; }

	[Position(2)]
	public string MonetaryAmountValue { get; set; }

	[Position(3)]
	public string DutyTaxFeeRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E020_TaxDetails>(this);
		validator.Required(x=>x.DutyTaxFeeTypeNameCode);
		validator.Length(x => x.DutyTaxFeeTypeNameCode, 1, 3);
		validator.Length(x => x.MonetaryAmountValue, 1, 35);
		validator.Length(x => x.DutyTaxFeeRate, 1, 17);
		return validator.Results;
	}
}
