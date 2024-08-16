using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("TXS")]
public class TXS_Taxes : EdifactSegment
{
	[Position(1)]
	public E020_TaxDetails TaxDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TXS_Taxes>(this);
		validator.Required(x=>x.TaxDetails);
		return validator.Results;
	}
}
