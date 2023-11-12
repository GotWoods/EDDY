using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("G93")]
public class G93_PriceBracketIdentification : EdiX12Segment
{
	[Position(01)]
	public string PriceBracketIdentifier { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string FreeFormDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G93_PriceBracketIdentification>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		return validator.Results;
	}
}
