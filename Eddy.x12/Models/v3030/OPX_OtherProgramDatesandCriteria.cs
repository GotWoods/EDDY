using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("OPX")]
public class OPX_OtherProgramDatesAndCriteria : EdiX12Segment
{
	[Position(01)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(02)]
	public string DateTimePeriod { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(04)]
	public string DateTimePeriod2 { get; set; }

	[Position(05)]
	public string PlacementCriteriaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OPX_OtherProgramDatesAndCriteria>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.PlacementCriteriaCode, 1);
		return validator.Results;
	}
}
