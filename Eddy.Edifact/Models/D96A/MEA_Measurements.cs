using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("MEA")]
public class MEA_Measurements : EdifactSegment
{
	[Position(1)]
	public string MeasurementApplicationQualifier { get; set; }

	[Position(2)]
	public C502_MeasurementDetails MeasurementDetails { get; set; }

	[Position(3)]
	public C174_ValueRange ValueRange { get; set; }

	[Position(4)]
	public string SurfaceLayerIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MEA_Measurements>(this);
		validator.Required(x=>x.MeasurementApplicationQualifier);
		validator.Length(x => x.MeasurementApplicationQualifier, 1, 3);
		validator.Length(x => x.SurfaceLayerIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
