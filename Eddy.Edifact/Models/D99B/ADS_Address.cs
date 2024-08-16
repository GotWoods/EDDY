using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ADS")]
public class ADS_Address : EdifactSegment
{
	[Position(1)]
	public E817_AddressUsage AddressUsage { get; set; }

	[Position(2)]
	public E001_AddressDetails AddressDetails { get; set; }

	[Position(3)]
	public string CityName { get; set; }

	[Position(4)]
	public string PostalIdentificationCode { get; set; }

	[Position(5)]
	public string CountryNameCode { get; set; }

	[Position(6)]
	public E819_CountrySubEntityDetails CountrySubEntityDetails { get; set; }

	[Position(7)]
	public E517_LocationIdentification LocationIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ADS_Address>(this);
		validator.Length(x => x.CityName, 1, 35);
		validator.Length(x => x.PostalIdentificationCode, 1, 17);
		validator.Length(x => x.CountryNameCode, 1, 3);
		return validator.Results;
	}
}
