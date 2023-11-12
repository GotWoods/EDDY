using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8020;

[Segment("MKS")]
public class MKS_MarksAwarded : EdiX12Segment
{
	[Position(01)]
	public string MarkCodeType { get; set; }

	[Position(02)]
	public string AcademicGradeQualifier { get; set; }

	[Position(03)]
	public string AcademicGrade { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MKS_MarksAwarded>(this);
		validator.ARequiresB(x=>x.AcademicGrade, x=>x.AcademicGradeQualifier);
		validator.Length(x => x.MarkCodeType, 1, 2);
		validator.Length(x => x.AcademicGradeQualifier, 1, 3);
		validator.Length(x => x.AcademicGrade, 1, 3);
		return validator.Results;
	}
}
