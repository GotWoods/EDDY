using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("DTP")]
public class DTP_DateOrTimeOrPeriod : EdiX12Segment
{
	[Position(01)]
	public string DateTimeQualifier { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DTP_DateOrTimeOrPeriod>(this);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		return validator.Results;
	}
}
