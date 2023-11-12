using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("N10")]
public class N10_QuantityAndDescription : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string FreeFormDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N10_QuantityAndDescription>(this);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		return validator.Results;
	}
}
