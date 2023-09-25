using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SST")]
public class SST_StudentAcademicStatus : EdiX12Segment
{
	[Position(01)]
	public string StatusReasonCode { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string StatusReasonCode2 { get; set; }

	[Position(05)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(06)]
	public string DateTimePeriod2 { get; set; }

	[Position(07)]
	public string StatusReasonCode3 { get; set; }

	[Position(08)]
	public string LevelOfStudentOrTestCode { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SST_StudentAcademicStatus>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.StatusReasonCode2, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.StatusReasonCode3, 3);
		validator.Length(x => x.LevelOfStudentOrTestCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
