using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("MNC")]
public class MNC_MortgageNoteCharacteristics : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string RealEstateLoanTypeCode { get; set; }

	[Position(03)]
	public string LienPriorityCode { get; set; }

	[Position(04)]
	public string LoanPaymentTypeCode { get; set; }

	[Position(05)]
	public string LoanRateTypeCode { get; set; }

	[Position(06)]
	public string FrequencyCode { get; set; }

	[Position(07)]
	public string InterestRateCalculationMethodCode { get; set; }

	[Position(08)]
	public int? Number { get; set; }

	[Position(09)]
	public int? Number2 { get; set; }

	[Position(10)]
	public string PaymentMethodCode { get; set; }

	[Position(11)]
	public string InterestPaymentCode { get; set; }

	[Position(12)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(13)]
	public string ProductServiceID { get; set; }

	[Position(14)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(15)]
	public string ProductDescriptionCode { get; set; }

	[Position(16)]
	public string TypeOfRealEstateAssetCode { get; set; }

	[Position(17)]
	public string RealEstateLoanSecurityInstrumentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MNC_MortgageNoteCharacteristics>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Number, x=>x.Number2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductProcessCharacteristicCode, x=>x.ProductDescriptionCode);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.RealEstateLoanTypeCode, 1);
		validator.Length(x => x.LienPriorityCode, 1);
		validator.Length(x => x.LoanPaymentTypeCode, 2);
		validator.Length(x => x.LoanRateTypeCode, 1);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.InterestRateCalculationMethodCode, 1);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		validator.Length(x => x.PaymentMethodCode, 1);
		validator.Length(x => x.InterestPaymentCode, 1, 2);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.TypeOfRealEstateAssetCode, 2);
		validator.Length(x => x.RealEstateLoanSecurityInstrumentCode, 1);
		return validator.Results;
	}
}
