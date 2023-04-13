using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("INV")]
public class INV_InvestmentVehicleSelection : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	[Position(02)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string StateOrProvinceCode { get; set; }

	[Position(06)]
	public string Description2 { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INV_InvestmentVehicleSelection>(this);
		validator.Required(x=>x.Description);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		return validator.Results;
	}
}
