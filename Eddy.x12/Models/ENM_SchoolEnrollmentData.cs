using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("ENM")]
public class ENM_SchoolEnrollmentData : EdiX12Segment
{
	[Position(01)]
	public string StatusReasonCode { get; set; }

	[Position(02)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(03)]
	public string SessionCode { get; set; }

	[Position(04)]
	public C056_CompositeRaceOrEthnicityInformation CompositeRaceOrEthnicityInformation { get; set; }

	[Position(05)]
	public string GenderCode { get; set; }

	[Position(06)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(07)]
	public string DateTimePeriod { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ENM_SchoolEnrollmentData>(this);
		validator.Required(x=>x.StatusReasonCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.SessionCode, 1);
		validator.Length(x => x.GenderCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
