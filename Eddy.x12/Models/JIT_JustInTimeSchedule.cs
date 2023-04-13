using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("JIT")]
public class JIT_JustInTimeSchedule : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<JIT_JustInTimeSchedule>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.Time);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Time, 4, 8);
		return validator.Results;
	}
}
