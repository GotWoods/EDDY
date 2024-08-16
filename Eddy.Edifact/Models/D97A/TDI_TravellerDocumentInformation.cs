using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("TDI")]
public class TDI_TravellerDocumentInformation : EdifactSegment
{
	[Position(1)]
	public E968_DocumentInformation DocumentInformation { get; set; }

	[Position(2)]
	public E969_ValidityDates ValidityDates { get; set; }

	[Position(3)]
	public string Surname { get; set; }

	[Position(4)]
	public string GivenName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TDI_TravellerDocumentInformation>(this);
		validator.Required(x=>x.DocumentInformation);
		validator.Length(x => x.Surname, 1, 70);
		validator.Length(x => x.GivenName, 1, 70);
		return validator.Results;
	}
}
