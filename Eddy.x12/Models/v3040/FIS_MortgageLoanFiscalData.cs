using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("FIS")]
public class FIS_MortgageLoanFiscalData : EdiX12Segment
{
	[Position(01)]
	public string AmountQualifierCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FIS_MortgageLoanFiscalData>(this);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		return validator.Results;
	}
}
