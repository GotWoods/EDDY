using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C502")]
public class C502_MeasurementDetails : EdifactComponent
{
	[Position(1)]
	public string MeasurementDimensionCoded { get; set; }

	[Position(2)]
	public string MeasurementSignificanceCoded { get; set; }

	[Position(3)]
	public string MeasurementAttributeIdentification { get; set; }

	[Position(4)]
	public string MeasurementAttribute { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C502_MeasurementDetails>(this);
		validator.Length(x => x.MeasurementDimensionCoded, 1, 3);
		validator.Length(x => x.MeasurementSignificanceCoded, 1, 3);
		validator.Length(x => x.MeasurementAttributeIdentification, 1, 17);
		validator.Length(x => x.MeasurementAttribute, 1, 70);
		return validator.Results;
	}
}
