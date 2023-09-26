using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("CGS")]
public class CGS_Charge : EdiX12Segment
{
	[Position(01)]
	public string AmountCharged { get; set; }

	[Position(02)]
	public string CurrencyCode { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CGS_Charge>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountCharged, x=>x.SpecialChargeOrAllowanceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier, x=>x.Date);
		validator.Length(x => x.AmountCharged, 1, 12);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		return validator.Results;
	}
}
