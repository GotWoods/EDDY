using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G33")]
public class G33_TotalDollarsSummary : EdiX12Segment
{
	[Position(01)]
	public string Amount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G33_TotalDollarsSummary>(this);
		validator.Required(x=>x.Amount);
		validator.Length(x => x.Amount, 1, 15);
		return validator.Results;
	}
}
