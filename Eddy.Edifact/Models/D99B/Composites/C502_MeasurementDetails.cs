using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C502")]
public class C502_MeasurementDetails : EdifactComponent
{
	[Position(1)]
	public string MeasuredAttributeCode { get; set; }

	[Position(2)]
	public string MeasurementSignificanceCoded { get; set; }

	[Position(3)]
	public string NonDiscreteMeasurementNameCode { get; set; }

	[Position(4)]
	public string NonDiscreteMeasurementName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C502_MeasurementDetails>(this);
		validator.Length(x => x.MeasuredAttributeCode, 1, 3);
		validator.Length(x => x.MeasurementSignificanceCoded, 1, 3);
		validator.Length(x => x.NonDiscreteMeasurementNameCode, 1, 17);
		validator.Length(x => x.NonDiscreteMeasurementName, 1, 70);
		return validator.Results;
	}
}
