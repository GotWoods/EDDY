using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("PEX")]
public class PEX_PropertyOrHousingExpense : EdiX12Segment
{
	[Position(01)]
	public string GeneralExpenseQualifier { get; set; }

	[Position(02)]
	public string RateValueQualifier { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public string TaxTypeCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(06)]
	public string EntityIdentifierCode { get; set; }

	[Position(07)]
	public string TaxExemptCode { get; set; }

	[Position(08)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PEX_PropertyOrHousingExpense>(this);
		validator.Required(x=>x.GeneralExpenseQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier, x=>x.MonetaryAmount);
		validator.Length(x => x.GeneralExpenseQualifier, 2);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.TaxTypeCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.TaxExemptCode, 1);
		return validator.Results;
	}
}
