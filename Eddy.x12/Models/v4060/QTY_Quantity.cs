using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060.Composites;

namespace Eddy.x12.Models.v4060;

[Segment("QTY")]
public class QTY_QuantityInformation : EdiX12Segment
{
	[Position(01)]
	public string QuantityQualifier { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(04)]
	public string FreeFormInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<QTY_QuantityInformation>(this);
		validator.Required(x=>x.QuantityQualifier);
		validator.AtLeastOneIsRequired(x=>x.Quantity, x=>x.FreeFormInformation);
		validator.OnlyOneOf(x=>x.Quantity, x=>x.FreeFormInformation);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormInformation, 1, 30);
		return validator.Results;
	}
}
