using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C840")]
public class C840_AttendanceAdmissionDetails : EdifactComponent
{
	[Position(1)]
	public string AdmissionTypeCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string AdmissionType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C840_AttendanceAdmissionDetails>(this);
		validator.Length(x => x.AdmissionTypeCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.AdmissionType, 1, 35);
		return validator.Results;
	}
}
