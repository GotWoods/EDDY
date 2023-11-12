using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("FU2")]
public class FU2_DealValue : EdiX12Segment
{
	[Position(01)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(07)]
	public string TransportationTermsCode { get; set; }

	[Position(08)]
	public string LocationQualifier { get; set; }

	[Position(09)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(10)]
	public string IdentificationCode { get; set; }

	[Position(11)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FU2_DealValue>(this);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.AtLeastOneIsRequired(x=>x.Quantity, x=>x.MonetaryAmount);
		validator.OnlyOneOf(x=>x.Quantity, x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TransportationTermsCode, x=>x.LocationQualifier);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.TransportationTermsCode, x=>x.IdentificationCodeQualifier, x=>x.Description2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.TransportationTermsCode, 3);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
