using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("MEA")]
public class MEA_Measurements : EdifactSegment
{
	[Position(1)]
	public string MeasurementAttributeCode { get; set; }

	[Position(2)]
	public C502_MeasurementDetails MeasurementDetails { get; set; }

	[Position(3)]
	public C174_ValueRange ValueRange { get; set; }

	[Position(4)]
	public string SurfaceOrLayerCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MEA_Measurements>(this);
		validator.Required(x=>x.MeasurementAttributeCode);
		validator.Length(x => x.MeasurementAttributeCode, 1, 3);
		validator.Length(x => x.SurfaceOrLayerCode, 1, 3);
		return validator.Results;
	}
}