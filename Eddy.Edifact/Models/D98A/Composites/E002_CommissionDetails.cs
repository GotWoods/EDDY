using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98A.Composites;

[Segment("E002")]
public class E002_CommissionDetails : EdifactComponent
{
	[Position(1)]
	public string PaymentConditionsCoded { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string CurrencyCoded { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	[Position(5)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E002_CommissionDetails>(this);
		validator.Required(x=>x.PaymentConditionsCoded);
		validator.Length(x => x.PaymentConditionsCoded, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.FreeText, 1, 70);
		return validator.Results;
	}
}
