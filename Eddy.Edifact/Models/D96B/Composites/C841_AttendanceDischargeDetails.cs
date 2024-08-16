using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C841")]
public class C841_AttendanceDischargeDetails : EdifactComponent
{
	[Position(1)]
	public string DischargeTypeCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string DischargeType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C841_AttendanceDischargeDetails>(this);
		validator.Length(x => x.DischargeTypeCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.DischargeType, 1, 35);
		return validator.Results;
	}
}
