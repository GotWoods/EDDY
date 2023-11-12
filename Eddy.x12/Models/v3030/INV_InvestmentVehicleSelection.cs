using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("INV")]
public class INV_InvestmentVehicleSelection : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	[Position(02)]
	public decimal? Percent { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INV_InvestmentVehicleSelection>(this);
		validator.Required(x=>x.Description);
		validator.OnlyOneOf(x=>x.Percent, x=>x.MonetaryAmount);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		return validator.Results;
	}
}
