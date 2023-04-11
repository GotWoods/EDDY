using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G36")]
public class G36_PriceListReference : EdiX12Segment
{
	[Position(01)]
	public string PriceListNumber { get; set; }

	[Position(02)]
	public string PriceListIssueNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string PriceConditionAppliesCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G36_PriceListReference>(this);
		validator.Required(x=>x.PriceListNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.PriceListNumber, 1, 16);
		validator.Length(x => x.PriceListIssueNumber, 1, 16);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.PriceConditionAppliesCode, 3);
		return validator.Results;
	}
}
