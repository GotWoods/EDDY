using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TAR")]
public class TAR_TargetMarket : EdiX12Segment
{
	[Position(01)]
	public string CityName { get; set; }

	[Position(02)]
	public string PostalCodeFormatted { get; set; }

	[Position(03)]
	public string CountrySubdivisionCode { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	[Position(05)]
	public string MarketAreaCodeQualifier { get; set; }

	[Position(06)]
	public string MarketAreaCodeIdentifier { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TAR_TargetMarket>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.MarketAreaCodeQualifier, x=>x.MarketAreaCodeIdentifier, x=>x.Description);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.PostalCodeFormatted, 3, 20);
		validator.Length(x => x.CountrySubdivisionCode, 1, 3);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.MarketAreaCodeQualifier, 1, 3);
		validator.Length(x => x.MarketAreaCodeIdentifier, 1, 13);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
