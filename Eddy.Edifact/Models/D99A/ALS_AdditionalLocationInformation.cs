using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("ALS")]
public class ALS_AdditionalLocationInformation : EdifactSegment
{
	[Position(1)]
	public string PlaceLocationQualifier { get; set; }

	[Position(2)]
	public E975_Location Location { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ALS_AdditionalLocationInformation>(this);
		validator.Required(x=>x.PlaceLocationQualifier);
		validator.Required(x=>x.Location);
		validator.Length(x => x.PlaceLocationQualifier, 1, 3);
		return validator.Results;
	}
}
