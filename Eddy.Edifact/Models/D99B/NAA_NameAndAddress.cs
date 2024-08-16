using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("NAA")]
public class NAA_NameAndAddress : EdifactSegment
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(2)]
	public E082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(3)]
	public string NameAndAddressLine { get; set; }

	[Position(4)]
	public E080_PartyName PartyName { get; set; }

	[Position(5)]
	public string StreetAndNumberPOBox { get; set; }

	[Position(6)]
	public string CityName { get; set; }

	[Position(7)]
	public string CountrySubEntityNameCode { get; set; }

	[Position(8)]
	public string PostalIdentificationCode { get; set; }

	[Position(9)]
	public string CountryNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NAA_NameAndAddress>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.NameAndAddressLine, 1, 35);
		validator.Length(x => x.StreetAndNumberPOBox, 1, 35);
		validator.Length(x => x.CityName, 1, 35);
		validator.Length(x => x.CountrySubEntityNameCode, 1, 9);
		validator.Length(x => x.PostalIdentificationCode, 1, 17);
		validator.Length(x => x.CountryNameCode, 1, 3);
		return validator.Results;
	}
}
