using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("PDE")]
public class PDE_PropertyMetesAndBoundsDescription : EdiX12Segment
{
	[Position(01)]
	public string FreeFormMessageText { get; set; }

	[Position(02)]
	public string DirectionIdentifierCode { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(04)]
	public decimal? MeasurementValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDE_PropertyMetesAndBoundsDescription>(this);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.DirectionIdentifierCode, 1);
		validator.Length(x => x.MeasurementValue, 1, 20);
		return validator.Results;
	}
}
