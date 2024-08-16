using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Models.D00B;

[Segment("ALS")]
public class ALS_AdditionalLocationInformation : EdifactSegment
{
	[Position(1)]
	public string LocationFunctionCodeQualifier { get; set; }

	[Position(2)]
	public E975_Location Location { get; set; }

	[Position(3)]
	public string LatitudeValue { get; set; }

	[Position(4)]
	public string LongitudeValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ALS_AdditionalLocationInformation>(this);
		validator.Required(x=>x.LocationFunctionCodeQualifier);
		validator.Required(x=>x.Location);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.LatitudeValue, 1, 10);
		validator.Length(x => x.LongitudeValue, 1, 11);
		return validator.Results;
	}
}
