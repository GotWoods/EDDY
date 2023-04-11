using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("CST")]
public class CST_CostAnalysis : EdiX12Segment
{
	[Position(01)]
	public string CostCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CST_CostAnalysis>(this);
		validator.Required(x=>x.CostCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.CostCode, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
