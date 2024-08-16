using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C840")]
public class C840_AttendanceAdmissionDetails : EdifactComponent
{
	[Position(1)]
	public string AdmissionTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string AdmissionTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C840_AttendanceAdmissionDetails>(this);
		validator.Length(x => x.AdmissionTypeDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AdmissionTypeDescription, 1, 35);
		return validator.Results;
	}
}
