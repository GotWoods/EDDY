using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E020")]
public class E020_TaxDetails : EdifactComponent
{
	[Position(1)]
	public string DutyTaxFeeTypeCoded { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string DutyTaxFeeRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E020_TaxDetails>(this);
		validator.Required(x=>x.DutyTaxFeeTypeCoded);
		validator.Length(x => x.DutyTaxFeeTypeCoded, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.DutyTaxFeeRate, 1, 17);
		return validator.Results;
	}
}
