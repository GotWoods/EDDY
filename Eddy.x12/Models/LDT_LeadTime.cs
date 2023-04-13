using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("LDT")]
public class LDT_LeadTime : EdiX12Segment
{
	[Position(01)]
	public string LeadTimeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOfTimePeriodOrIntervalCode { get; set; }

	[Position(04)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LDT_LeadTime>(this);
		validator.Required(x=>x.LeadTimeCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfTimePeriodOrIntervalCode);
		validator.Length(x => x.LeadTimeCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
