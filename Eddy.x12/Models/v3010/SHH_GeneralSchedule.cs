using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SHH")]
public class SHH_GeneralSchedule : EdiX12Segment
{
	[Position(01)]
	public string SchedulingShippingCode { get; set; }

	[Position(02)]
	public string DateTimeQualifier { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SHH_GeneralSchedule>(this);
		validator.Required(x=>x.SchedulingShippingCode);
		validator.Length(x => x.SchedulingShippingCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4);
		return validator.Results;
	}
}
