using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PPA_PropertyLocation>(this);
		validator.Required(x=>x.LocationQualifier);
		validator.Required(x=>x.LocationIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LongitudeCode, x=>x.DirectionIdentifierCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LatitudeCode, x=>x.DirectionIdentifierCode2);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LongitudeCode, 7);
		validator.Length(x => x.DirectionIdentifierCode, 1);
		validator.Length(x => x.LatitudeCode, 7);
		validator.Length(x => x.DirectionIdentifierCode2, 1);
		return validator.Results;
	}
}
