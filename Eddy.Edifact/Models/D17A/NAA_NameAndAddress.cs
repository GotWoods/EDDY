using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17A.Composites;

namespace Eddy.Edifact.Models.D17A;

[Segment("NAA")]
public class NAA_NameAndAddress : EdifactSegment
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(2)]
	public E082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(3)]
	public string NameAndAddressDescription { get; set; }

	[Position(4)]
	public E080_PartyName PartyName { get; set; }

	[Position(5)]
	public string StreetAndNumberOrPostOfficeBoxIdentifier { get; set; }

	[Position(6)]
	public string CityName { get; set; }

	[Position(7)]
	public string CountrySubdivisionIdentifier { get; set; }

	[Position(8)]
	public string PostalIdentificationCode { get; set; }

	[Position(9)]
	public string CountryIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NAA_NameAndAddress>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.NameAndAddressDescription, 1, 35);
		validator.Length(x => x.StreetAndNumberOrPostOfficeBoxIdentifier, 1, 256);
		validator.Length(x => x.CityName, 1, 35);
		validator.Length(x => x.CountrySubdivisionIdentifier, 1, 9);
		validator.Length(x => x.PostalIdentificationCode, 1, 17);
		validator.Length(x => x.CountryIdentifier, 1, 3);
		return validator.Results;
	}
}
