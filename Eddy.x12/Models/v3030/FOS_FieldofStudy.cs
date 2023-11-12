using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("FOS")]
public class FOS_FieldOfStudy : EdiX12Segment
{
	[Position(01)]
	public string AcademicFieldOfStudyLevelOrTypeCode { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string FreeFormMessage { get; set; }

	[Position(05)]
	public string FreeFormMessage2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FOS_FieldOfStudy>(this);
		validator.Required(x=>x.AcademicFieldOfStudyLevelOrTypeCode);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Length(x => x.AcademicFieldOfStudyLevelOrTypeCode, 1);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.FreeFormMessage2, 1, 60);
		return validator.Results;
	}
}
