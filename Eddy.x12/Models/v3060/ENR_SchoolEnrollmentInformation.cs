using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("ENR")]
public class ENR_SchoolEnrollmentInformation : EdiX12Segment
{
	[Position(01)]
	public string StatusReasonCode { get; set; }

	[Position(02)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string MajorCourseOfStudy { get; set; }

	[Position(06)]
	public decimal? RangeMinimum { get; set; }

	[Position(07)]
	public decimal? RangeMaximum { get; set; }

	[Position(08)]
	public decimal? AcademicGradePointAverage { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(12)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(13)]
	public string DateTimePeriod2 { get; set; }

	[Position(14)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(15)]
	public string DateTimePeriodFormatQualifier3 { get; set; }

	[Position(16)]
	public string DateTimePeriod3 { get; set; }

	[Position(17)]
	public string DateTimePeriodFormatQualifier4 { get; set; }

	[Position(18)]
	public string DateTimePeriod4 { get; set; }

	[Position(19)]
	public string YesNoConditionOrResponseCode5 { get; set; }

	[Position(20)]
	public string YesNoConditionOrResponseCode6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ENR_SchoolEnrollmentInformation>(this);
		validator.Required(x=>x.StatusReasonCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier3, x=>x.DateTimePeriod3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier4, x=>x.DateTimePeriod4);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.MajorCourseOfStudy, 1, 2);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		validator.Length(x => x.AcademicGradePointAverage, 1, 6);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier3, 2, 3);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier4, 2, 3);
		validator.Length(x => x.DateTimePeriod4, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode5, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode6, 1);
		return validator.Results;
	}
}
