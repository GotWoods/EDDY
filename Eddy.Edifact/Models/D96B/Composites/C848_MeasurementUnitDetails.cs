using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C848")]
public class C848_MeasurementUnitDetails : EdifactComponent
{
	[Position(1)]
	public string MeasurementUnitIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string MeasurementUnit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C848_MeasurementUnitDetails>(this);
		validator.Length(x => x.MeasurementUnitIdentification, 1, 8);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.MeasurementUnit, 1, 35);
		return validator.Results;
	}
}
