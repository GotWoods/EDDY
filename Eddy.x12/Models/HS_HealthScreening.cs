using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("HS")]
public class HS_HealthScreening : EdiX12Segment
{
	[Position(01)]
	public string IndustryCode { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string StatusReasonCode { get; set; }

	[Position(05)]
	public string CodeListQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HS_HealthScreening>(this);
		validator.Required(x=>x.IndustryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		return validator.Results;
	}
}
