using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TII")]
public class TII_TaxInstallmentInformation : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public string TaxServiceNonPaymentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TII_TaxInstallmentInformation>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.TaxServiceNonPaymentCode, 1, 3);
		return validator.Results;
	}
}
