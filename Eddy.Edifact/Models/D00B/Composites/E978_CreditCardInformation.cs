using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E978")]
public class E978_CreditCardInformation : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string ReferenceIdentifier { get; set; }

	[Position(3)]
	public string DateValue { get; set; }

	[Position(4)]
	public string BankIdentifier { get; set; }

	[Position(5)]
	public string TravellerReferenceIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E978_CreditCardInformation>(this);
		validator.Required(x=>x.PartyName);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.ReferenceIdentifier, 1, 70);
		validator.Length(x => x.DateValue, 1, 14);
		validator.Length(x => x.BankIdentifier, 1, 17);
		validator.Length(x => x.TravellerReferenceIdentifier, 1, 35);
		return validator.Results;
	}
}
