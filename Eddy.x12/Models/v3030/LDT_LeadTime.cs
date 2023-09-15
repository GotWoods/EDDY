using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("LDT")]
public class LDT_LeadTime : EdiX12Segment
{
	[Position(01)]
	public string LeadTimeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(04)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LDT_LeadTime>(this);
		validator.Required(x=>x.LeadTimeCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfTimePeriodOrInterval);
		validator.Length(x => x.LeadTimeCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.Date, 6);
		return validator.Results;
	}
}
