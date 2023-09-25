using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("MII")]
public class MII_MortgageInsuranceInformation : EdiX12Segment
{
	[Position(01)]
	public string MortgageInsuranceApplicationType { get; set; }

	[Position(02)]
	public string MortgageInsurancePremiumTypeCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(04)]
	public string MortgageInsuranceCertificateTypeCode { get; set; }

	[Position(05)]
	public string MortgageInsuranceCoverageTypeCode { get; set; }

	[Position(06)]
	public string MortgageInsuranceDurationCode { get; set; }

	[Position(07)]
	public string MortgageInsuranceRenewalOptionCode { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount { get; set; }

	[Position(09)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(10)]
	public string ReferenceIdentification { get; set; }

	[Position(11)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(12)]
	public string ProductServiceID { get; set; }

	[Position(13)]
	public decimal? Percent { get; set; }

	[Position(14)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(15)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MII_MortgageInsuranceInformation>(this);
		validator.Required(x=>x.MortgageInsuranceApplicationType);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.Length(x => x.MortgageInsuranceApplicationType, 1);
		validator.Length(x => x.MortgageInsurancePremiumTypeCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.MortgageInsuranceCertificateTypeCode, 1);
		validator.Length(x => x.MortgageInsuranceCoverageTypeCode, 1);
		validator.Length(x => x.MortgageInsuranceDurationCode, 1);
		validator.Length(x => x.MortgageInsuranceRenewalOptionCode, 1);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
