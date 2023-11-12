using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("CSE")]
public class CSE_EducationalCourseInformation : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string AcademicCreditTypeCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public decimal? Quantity2 { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string AcademicGradeOrCourseLevelCode { get; set; }

	[Position(08)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(09)]
	public string IdentificationCode { get; set; }

	[Position(10)]
	public string EntityTitle { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSE_EducationalCourseInformation>(this);
		validator.AtLeastOneIsRequired(x=>x.Name, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.AcademicCreditTypeCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.AcademicGradeOrCourseLevelCode, 1, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.EntityTitle, 1, 132);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		return validator.Results;
	}
}
