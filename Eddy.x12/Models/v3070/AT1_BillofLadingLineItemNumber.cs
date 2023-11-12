using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("AT1")]
public class AT1_BillOfLadingLineItemNumber : EdiX12Segment
{
	[Position(01)]
	public int? LadingLineItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT1_BillOfLadingLineItemNumber>(this);
		validator.Required(x=>x.LadingLineItemNumber);
		validator.Length(x => x.LadingLineItemNumber, 1, 3);
		return validator.Results;
	}
}
