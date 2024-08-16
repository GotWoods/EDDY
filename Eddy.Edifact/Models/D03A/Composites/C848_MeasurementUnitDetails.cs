using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D03A.Composites;

[Segment("C848")]
public class C848_MeasurementUnitDetails : EdifactComponent
{
	[Position(1)]
	public string MeasurementUnitCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MeasurementUnitName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C848_MeasurementUnitDetails>(this);
		validator.Length(x => x.MeasurementUnitCode, 1, 8);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MeasurementUnitName, 1, 35);
		return validator.Results;
	}
}
