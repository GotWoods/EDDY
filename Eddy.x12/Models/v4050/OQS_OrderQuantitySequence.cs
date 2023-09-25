using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("OQS")]
public class OQS_OrderQuantitySequence : EdiX12Segment
{
	[Position(01)]
	public decimal? SequenceValue { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OQS_OrderQuantitySequence>(this);
		validator.Required(x=>x.SequenceValue);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.SequenceValue, 1, 9);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
