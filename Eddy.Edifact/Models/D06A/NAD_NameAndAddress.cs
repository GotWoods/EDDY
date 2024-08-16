using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Models.D06A;

[Segment("NAD")]
public class NAD_NameAndAddress : EdifactSegment
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

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
	public C819_CountrySubdivisionDetails CountrySubdivisionDetails { get; set; }

	[Position(8)]
	public string PostalIdentificationCode { get; set; }

	[Position(9)]
	public string CountryIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NAD_NameAndAddress>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.CityName, 1, 35);
		validator.Length(x => x.PostalIdentificationCode, 1, 17);
		validator.Length(x => x.CountryIdentifier, 1, 3);
		return validator.Results;
	}
}
