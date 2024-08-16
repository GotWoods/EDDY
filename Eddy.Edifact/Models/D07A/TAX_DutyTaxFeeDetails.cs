using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07A.Composites;

namespace Eddy.Edifact.Models.D07A;

[Segment("TAX")]
public class TAX_DutyTaxFeeDetails : EdifactSegment
{
	[Position(1)]
	public string DutyOrTaxOrFeeFunctionCodeQualifier { get; set; }

	[Position(2)]
	public C241_DutyTaxFeeType DutyTaxFeeType { get; set; }

	[Position(3)]
	public C533_DutyTaxFeeAccountDetail DutyTaxFeeAccountDetail { get; set; }

	[Position(4)]
	public string DutyOrTaxOrFeeAssessmentBasisQuantity { get; set; }

	[Position(5)]
	public C243_DutyTaxFeeDetail DutyTaxFeeDetail { get; set; }

	[Position(6)]
	public string DutyOrTaxOrFeeCategoryCode { get; set; }

	[Position(7)]
	public string PartyTaxIdentifier { get; set; }

	[Position(8)]
	public string CalculationSequenceCode { get; set; }

	[Position(9)]
	public string TaxOrDutyOrFeePaymentDueDateCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TAX_DutyTaxFeeDetails>(this);
		validator.Required(x=>x.DutyOrTaxOrFeeFunctionCodeQualifier);
		validator.Length(x => x.DutyOrTaxOrFeeFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.DutyOrTaxOrFeeAssessmentBasisQuantity, 1, 15);
		validator.Length(x => x.DutyOrTaxOrFeeCategoryCode, 1, 3);
		validator.Length(x => x.PartyTaxIdentifier, 1, 20);
		validator.Length(x => x.CalculationSequenceCode, 1, 3);
		validator.Length(x => x.TaxOrDutyOrFeePaymentDueDateCode, 1, 3);
		return validator.Results;
	}
}
