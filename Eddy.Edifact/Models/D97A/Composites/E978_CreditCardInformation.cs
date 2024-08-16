using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E978")]
public class E978_CreditCardInformation : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string ReferenceNumber { get; set; }

	[Position(3)]
	public string Date { get; set; }

	[Position(4)]
	public string BankIdentification { get; set; }

	[Position(5)]
	public string TravellerReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E978_CreditCardInformation>(this);
		validator.Required(x=>x.PartyName);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.ReferenceNumber, 1, 35);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.BankIdentification, 1, 17);
		validator.Length(x => x.TravellerReferenceNumber, 1, 35);
		return validator.Results;
	}
}
