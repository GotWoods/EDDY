using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7050;

[Segment("PPA")]
public class PPA_PropertyLocation : EdiX12Segment
{
	[Position(01)]
	public string LocationQualifier { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public string LongitudeCode { get; set; }

	[Position(04)]
	public string DirectionIdentifierCode { get; set; }

	[Position(05)]
	public string LatitudeCode { get; set; }

	[Position(06)]
	public string DirectionIdentifierCode2 { get; set; }

	[Position(07)]
	public decimal? LongitudeDecimalFormat { get; set; }

	[Position(08)]
	public decimal? LatitudeDecimalFormat { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PPA_PropertyLocation>(this);
		validator.Required(x=>x.LocationQualifier);
		validator.Required(x=>x.LocationIdentifier);
		validator.AtLeastOneIsRequired(x=>x.LongitudeCode, x=>x.DirectionIdentifierCode);
		validator.AtLeastOneIsRequired(x=>x.LongitudeCode, x=>x.LongitudeDecimalFormat);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LongitudeCode, x=>x.LatitudeCode);
		validator.OnlyOneOf(x=>x.LongitudeCode, x=>x.LongitudeDecimalFormat);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DirectionIdentifierCode, x=>x.LongitudeCode, x=>x.LongitudeDecimalFormat);
		validator.AtLeastOneIsRequired(x=>x.LatitudeCode, x=>x.DirectionIdentifierCode2);
		validator.AtLeastOneIsRequired(x=>x.LatitudeCode, x=>x.LatitudeDecimalFormat);
		validator.OnlyOneOf(x=>x.LatitudeCode, x=>x.LatitudeDecimalFormat);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DirectionIdentifierCode2, x=>x.LatitudeCode, x=>x.LatitudeDecimalFormat);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LongitudeDecimalFormat, x=>x.LatitudeDecimalFormat);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LongitudeCode, 7, 10);
		validator.Length(x => x.DirectionIdentifierCode, 1);
		validator.Length(x => x.LatitudeCode, 7, 10);
		validator.Length(x => x.DirectionIdentifierCode2, 1);
		validator.Length(x => x.LongitudeDecimalFormat, 1, 10);
		validator.Length(x => x.LatitudeDecimalFormat, 1, 10);
		return validator.Results;
	}
}
