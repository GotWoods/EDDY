using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04A.Composites;

namespace Eddy.Edifact.Models.D04A;

[Segment("GPO")]
public class GPO_GeographicalPosition : EdifactSegment
{
	[Position(1)]
	public string GeographicalPositionCodeQualifier { get; set; }

	[Position(2)]
	public string LatitudeDegree { get; set; }

	[Position(3)]
	public string LongitudeDegree { get; set; }

	[Position(4)]
	public string Altitude { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GPO_GeographicalPosition>(this);
		validator.Required(x=>x.GeographicalPositionCodeQualifier);
		validator.Length(x => x.GeographicalPositionCodeQualifier, 1, 3);
		validator.Length(x => x.LatitudeDegree, 1, 10);
		validator.Length(x => x.LongitudeDegree, 1, 11);
		validator.Length(x => x.Altitude, 1, 18);
		return validator.Results;
	}
}
