using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BT2")]
public class BT2_EndOfFiscalTimePeriod : EdiX12Segment
{
	[Position(01)]
	public string TimePeriodQualifier { get; set; }

	[Position(02)]
	public int? TimePeriodCompleted { get; set; }

	[Position(03)]
	public string TimePeriodQualifier2 { get; set; }

	[Position(04)]
	public int? TimePeriodCompleted2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BT2_EndOfFiscalTimePeriod>(this);
		validator.Required(x=>x.TimePeriodQualifier);
		validator.Required(x=>x.TimePeriodCompleted);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TimePeriodQualifier2, x=>x.TimePeriodCompleted2);
		validator.Length(x => x.TimePeriodQualifier, 1);
		validator.Length(x => x.TimePeriodCompleted, 2);
		validator.Length(x => x.TimePeriodQualifier2, 1);
		validator.Length(x => x.TimePeriodCompleted2, 2);
		return validator.Results;
	}
}
