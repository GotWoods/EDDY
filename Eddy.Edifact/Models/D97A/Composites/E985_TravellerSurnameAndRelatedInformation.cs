using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E985")]
public class E985_TravellerSurnameAndRelatedInformation : EdifactComponent
{
	[Position(1)]
	public string Surname { get; set; }

	[Position(2)]
	public string PartyQualifier { get; set; }

	[Position(3)]
	public string Quantity { get; set; }

	[Position(4)]
	public string StatusCoded { get; set; }

	[Position(5)]
	public string LanguageCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E985_TravellerSurnameAndRelatedInformation>(this);
		validator.Required(x=>x.Surname);
		validator.Length(x => x.Surname, 1, 70);
		validator.Length(x => x.PartyQualifier, 1, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.StatusCoded, 1, 3);
		validator.Length(x => x.LanguageCoded, 1, 3);
		return validator.Results;
	}
}
