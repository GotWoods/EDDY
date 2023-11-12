using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("TST")]
public class TST_TestScoreRecord : EdiX12Segment
{
	[Position(01)]
	public string EducationalTestOrRequirementCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(08)]
	public string LevelOfIndividualTestOrCourseCode2 { get; set; }

	[Position(09)]
	public string DateTimePeriod2 { get; set; }

	[Position(10)]
	public string TestNormTypeCode { get; set; }

	[Position(11)]
	public string TestNormingPeriodCode { get; set; }

	[Position(12)]
	public string LanguageCode { get; set; }

	[Position(13)]
	public string DateTimePeriod3 { get; set; }

	[Position(14)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(15)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(16)]
	public string TestScoreInterpretationCode { get; set; }

	[Position(17)]
	public string AcademicSummarySource { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TST_TestScoreRecord>(this);
		validator.Required(x=>x.EducationalTestOrRequirementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.EducationalTestOrRequirementCode, 1, 3);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode2, 2);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.TestNormTypeCode, 1);
		validator.Length(x => x.TestNormingPeriodCode, 1);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.TestScoreInterpretationCode, 1);
		validator.Length(x => x.AcademicSummarySource, 1);
		return validator.Results;
	}
}
