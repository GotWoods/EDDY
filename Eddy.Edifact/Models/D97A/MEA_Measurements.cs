using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("MEA")]
public class MEA_Measurements : EdifactSegment
{
	[Position(1)]
	public string MeasurementPurposeQualifier { get; set; }

	[Position(2)]
	public C502_MeasurementDetails MeasurementDetails { get; set; }

	[Position(3)]
	public C174_ValueRange ValueRange { get; set; }

	[Position(4)]
	public string SurfaceLayerIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MEA_Measurements>(this);
		validator.Required(x=>x.MeasurementPurposeQualifier);
		validator.Length(x => x.MeasurementPurposeQualifier, 1, 3);
		validator.Length(x => x.SurfaceLayerIndicatorCoded, 1, 3);
		return validator.Results;
	}
}