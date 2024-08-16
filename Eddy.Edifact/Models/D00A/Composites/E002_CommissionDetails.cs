using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E002")]
public class E002_CommissionDetails : EdifactComponent
{
	[Position(1)]
	public string PaymentConditionsCode { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	[Position(5)]
	public string FreeTextValue { get; set; }

	[Position(6)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E002_CommissionDetails>(this);
		validator.Required(x=>x.PaymentConditionsCode);
		validator.Length(x => x.PaymentConditionsCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.FreeTextValue, 1, 512);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		return validator.Results;
	}
}
