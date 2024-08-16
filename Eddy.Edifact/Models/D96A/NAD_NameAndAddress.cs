using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("NAD")]
public class NAD_NameAndAddress : EdifactSegment
{
	[Position(1)]
	public string PartyQualifier { get; set; }

	[Position(2)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(3)]
	public C058_NameAndAddress NameAndAddress { get; set; }

	[Position(4)]
	public C080_PartyName PartyName { get; set; }

	[Position(5)]
	public C059_Street Street { get; set; }

	[Position(6)]
	public string CityName { get; set; }

	[Position(7)]
	public string CountrySubEntityIdentification { get; set; }

	[Position(8)]
	public string PostcodeIdentification { get; set; }

	[Position(9)]
	public string CountryCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NAD_NameAndAddress>(this);
		validator.Required(x=>x.PartyQualifier);
		validator.Length(x => x.PartyQualifier, 1, 3);
		validator.Length(x => x.CityName, 1, 35);
		validator.Length(x => x.CountrySubEntityIdentification, 1, 9);
		validator.Length(x => x.PostcodeIdentification, 1, 9);
		validator.Length(x => x.CountryCoded, 1, 3);
		return validator.Results;
	}
}
