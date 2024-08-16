using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Models.D01C;

[Segment("ALS")]
public class ALS_AdditionalLocationInformation : EdifactSegment
{
	[Position(1)]
	public string LocationFunctionCodeQualifier { get; set; }

	[Position(2)]
	public E975_Location Location { get; set; }

	[Position(3)]
	public string LatitudeDegree { get; set; }

	[Position(4)]
	public string LongitudeDegree { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ALS_AdditionalLocationInformation>(this);
		validator.Required(x=>x.LocationFunctionCodeQualifier);
		validator.Required(x=>x.Location);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.LatitudeDegree, 1, 10);
		validator.Length(x => x.LongitudeDegree, 1, 11);
		return validator.Results;
	}
}
