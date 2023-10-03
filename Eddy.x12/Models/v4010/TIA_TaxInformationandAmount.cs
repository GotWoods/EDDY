using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010.Composites;

namespace Eddy.x12.Models.v4010;

[Segment("TIA")]
public class TIA_TaxInformationAndAmount : EdiX12Segment
{
	[Position(01)]
	public C037_TaxFieldIdentification TaxFieldIdentification { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string FixedFormatInformation { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(06)]
	public decimal? Percent { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TIA_TaxInformationAndAmount>(this);
		validator.Required(x=>x.TaxFieldIdentification);
		validator.OnlyOneOf(x=>x.Percent, x=>x.MonetaryAmount2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.FixedFormatInformation, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		return validator.Results;
	}
}
