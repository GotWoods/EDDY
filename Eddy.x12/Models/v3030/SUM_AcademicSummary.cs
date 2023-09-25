using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SUM")]
public class SUM_AcademicSummary : EdiX12Segment
{
	[Position(01)]
	public string AcademicCreditTypeCode { get; set; }

	[Position(02)]
	public string AcademicGradeOrCourseLevelCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public decimal? Quantity2 { get; set; }

	[Position(06)]
	public decimal? Quantity3 { get; set; }

	[Position(07)]
	public decimal? RangeMinimum { get; set; }

	[Position(08)]
	public decimal? RangeMaximum { get; set; }

	[Position(09)]
	public decimal? AcademicGradePointAverage { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(11)]
	public int? ClassRank { get; set; }

	[Position(12)]
	public decimal? Quantity4 { get; set; }

	[Position(13)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(14)]
	public string DateTimePeriod { get; set; }

	[Position(15)]
	public int? NumberOfDays { get; set; }

	[Position(16)]
	public int? NumberOfDays2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SUM_AcademicSummary>(this);
		validator.ARequiresB(x=>x.Quantity, x=>x.AcademicCreditTypeCode);
		validator.ARequiresB(x=>x.Quantity2, x=>x.AcademicCreditTypeCode);
		validator.ARequiresB(x=>x.Quantity3, x=>x.AcademicCreditTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.AcademicCreditTypeCode, 1);
		validator.Length(x => x.AcademicGradeOrCourseLevelCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.RangeMinimum, 1, 10);
		validator.Length(x => x.RangeMaximum, 1, 10);
		validator.Length(x => x.AcademicGradePointAverage, 1, 6);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.ClassRank, 1, 4);
		validator.Length(x => x.Quantity4, 1, 15);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.NumberOfDays, 1, 3);
		validator.Length(x => x.NumberOfDays2, 1, 3);
		return validator.Results;
	}
}
