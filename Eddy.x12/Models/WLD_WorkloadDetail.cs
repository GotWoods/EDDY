using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("WLD")]
public class WLD_WorkloadDetail : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public string AcademicGradeOrCourseLevelCode { get; set; }

	[Position(04)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(05)]
	public int? Count { get; set; }

	[Position(06)]
	public string DayRotation { get; set; }

	[Position(07)]
	public int? Count2 { get; set; }

	[Position(08)]
	public string Name { get; set; }

	[Position(09)]
	public string InstructionalSettingCode { get; set; }

	[Position(10)]
	public decimal? PercentageAsDecimal { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<WLD_WorkloadDetail>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.AcademicGradeOrCourseLevelCode, 1, 2);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.DayRotation, 1, 7);
		validator.Length(x => x.Count2, 1, 9);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.InstructionalSettingCode, 1, 2);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		return validator.Results;
	}
}
