using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("TIA")]
public class TIA_TaxInformationAndAmount : EdiX12Segment
{
	[Position(01)]
	public string TaxInformationIdentificationNumber { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string FixedFormatInformation { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public decimal? Percent { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TIA_TaxInformationAndAmount>(this);
		validator.Required(x=>x.TaxInformationIdentificationNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.OnlyOneOf(x=>x.Percent, x=>x.MonetaryAmount2);
		validator.Length(x => x.TaxInformationIdentificationNumber, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.FixedFormatInformation, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		return validator.Results;
	}
}
