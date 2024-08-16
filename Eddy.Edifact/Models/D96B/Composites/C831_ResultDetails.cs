using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C831")]
public class C831_ResultDetails : EdifactComponent
{
	[Position(1)]
	public string MeasurementValue { get; set; }

	[Position(2)]
	public string MeasurementSignificanceCoded { get; set; }

	[Position(3)]
	public string MeasurementAttributeIdentification { get; set; }

	[Position(4)]
	public string CodeListQualifier { get; set; }

	[Position(5)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(6)]
	public string MeasurementAttribute { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C831_ResultDetails>(this);
		validator.Length(x => x.MeasurementValue, 1, 18);
		validator.Length(x => x.MeasurementSignificanceCoded, 1, 3);
		validator.Length(x => x.MeasurementAttributeIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.MeasurementAttribute, 1, 70);
		return validator.Results;
	}
}
