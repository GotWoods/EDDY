using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("PAS")]
public class PAS_Attendance : EdifactSegment
{
	[Position(1)]
	public string AttendanceTypeCodeQualifier { get; set; }

	[Position(2)]
	public C839_AttendeeCategory AttendeeCategory { get; set; }

	[Position(3)]
	public C840_AttendanceAdmissionDetails AttendanceAdmissionDetails { get; set; }

	[Position(4)]
	public C841_AttendanceDischargeDetails AttendanceDischargeDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAS_Attendance>(this);
		validator.Required(x=>x.AttendanceTypeCodeQualifier);
		validator.Length(x => x.AttendanceTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
