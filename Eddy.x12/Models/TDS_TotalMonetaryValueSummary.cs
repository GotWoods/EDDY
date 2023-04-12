using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TDS")]
public class TDS_TotalMonetaryValueSummary : EdiX12Segment
{
	[Position(01)]
	public string Amount { get; set; }

	[Position(02)]
	public string Amount2 { get; set; }

	[Position(03)]
	public string Amount3 { get; set; }

	[Position(04)]
	public string Amount4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TDS_TotalMonetaryValueSummary>(this);
		validator.Required(x=>x.Amount);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.Amount3, 1, 15);
		validator.Length(x => x.Amount4, 1, 15);
		return validator.Results;
	}
}
