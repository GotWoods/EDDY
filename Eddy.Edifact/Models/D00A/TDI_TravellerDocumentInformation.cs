using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("TDI")]
public class TDI_TravellerDocumentInformation : EdifactSegment
{
	[Position(1)]
	public E968_DocumentInformation DocumentInformation { get; set; }

	[Position(2)]
	public E969_ValidityDates ValidityDates { get; set; }

	[Position(3)]
	public string FamilyName { get; set; }

	[Position(4)]
	public string GivenName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TDI_TravellerDocumentInformation>(this);
		validator.Required(x=>x.DocumentInformation);
		validator.Length(x => x.FamilyName, 1, 70);
		validator.Length(x => x.GivenName, 1, 70);
		return validator.Results;
	}
}
