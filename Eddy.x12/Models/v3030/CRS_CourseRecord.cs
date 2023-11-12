using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CRS")]
public class CRS_CourseRecord : EdiX12Segment
{
	[Position(01)]
	public string BasisForAcademicCreditCode { get; set; }

	[Position(02)]
	public string AcademicCreditTypeCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public decimal? Quantity2 { get; set; }

	[Position(05)]
	public string AcademicGradeQualifier { get; set; }

	[Position(06)]
	public string AcademicGrade { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(08)]
	public string AcademicGradeOrCourseLevelCode { get; set; }

	[Position(09)]
	public string CourseRepeatOrNoCountIndicatorCode { get; set; }

	[Position(10)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(11)]
	public string IdentificationCode { get; set; }

	[Position(12)]
	public string AcademicQualityPoints { get; set; }

	[Position(13)]
	public string LevelOfStudentOrTestCode { get; set; }

	[Position(14)]
	public string Name { get; set; }

	[Position(15)]
	public string ReferenceNumber { get; set; }

	[Position(16)]
	public string Name2 { get; set; }

	[Position(17)]
	public int? NumberOfDays { get; set; }

	[Position(18)]
	public int? NumberOfDays2 { get; set; }

	[Position(19)]
	public string Date { get; set; }

	[Position(20)]
	public string OverrideAcademicCourseSourceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRS_CourseRecord>(this);
		validator.Required(x=>x.BasisForAcademicCreditCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AcademicGradeQualifier, x=>x.AcademicGrade);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.BasisForAcademicCreditCode, 1);
		validator.Length(x => x.AcademicCreditTypeCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.AcademicGradeQualifier, 1, 3);
		validator.Length(x => x.AcademicGrade, 1, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.AcademicGradeOrCourseLevelCode, 1, 2);
		validator.Length(x => x.CourseRepeatOrNoCountIndicatorCode, 1);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.AcademicQualityPoints, 2, 5);
		validator.Length(x => x.LevelOfStudentOrTestCode, 2);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Name2, 1, 35);
		validator.Length(x => x.NumberOfDays, 1, 3);
		validator.Length(x => x.NumberOfDays2, 1, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.OverrideAcademicCourseSourceCode, 2);
		return validator.Results;
	}
}
