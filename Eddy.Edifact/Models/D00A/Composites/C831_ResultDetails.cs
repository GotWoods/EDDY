using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C831")]
public class C831_ResultDetails : EdifactComponent
{
	[Position(1)]
	public string MeasurementValue { get; set; }

	[Position(2)]
	public string MeasurementSignificanceCode { get; set; }

	[Position(3)]
	public string NonDiscreteMeasurementNameCode { get; set; }

	[Position(4)]
	public string CodeListIdentificationCode { get; set; }

	[Position(5)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(6)]
	public string NonDiscreteMeasurementName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C831_ResultDetails>(this);
		validator.Length(x => x.MeasurementValue, 1, 18);
		validator.Length(x => x.MeasurementSignificanceCode, 1, 3);
		validator.Length(x => x.NonDiscreteMeasurementNameCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.NonDiscreteMeasurementName, 1, 70);
		return validator.Results;
	}
}
