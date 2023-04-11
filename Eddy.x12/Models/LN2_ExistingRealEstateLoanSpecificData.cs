using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("LN2")]
public class LN2_ExistingRealEstateLoanSpecificData : EdiX12Segment
{
	[Position(01)]
	public string LienPriorityCode { get; set; }

	[Position(02)]
	public string RealEstateLoanTypeCode { get; set; }

	[Position(03)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(04)]
	public string FrequencyCode { get; set; }

	[Position(05)]
	public string LoanPaymentTypeCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string AssumptionTermsCode { get; set; }

	[Position(08)]
	public string Name { get; set; }

	[Position(09)]
	public C040_ReferenceIdentifier ReferenceIdentifier { get; set; }

	[Position(10)]
	public string QuantityQualifier { get; set; }

	[Position(11)]
	public decimal? Quantity { get; set; }

	[Position(12)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LN2_ExistingRealEstateLoanSpecificData>(this);
		validator.Required(x=>x.LienPriorityCode);
		validator.Required(x=>x.RealEstateLoanTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PercentageAsDecimal, x=>x.FrequencyCode);
		validator.ARequiresB(x=>x.Quantity, x=>x.QuantityQualifier);
		validator.ARequiresB(x=>x.Quantity2, x=>x.QuantityQualifier);
		validator.Length(x => x.LienPriorityCode, 1);
		validator.Length(x => x.RealEstateLoanTypeCode, 1);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.LoanPaymentTypeCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.AssumptionTermsCode, 1);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
