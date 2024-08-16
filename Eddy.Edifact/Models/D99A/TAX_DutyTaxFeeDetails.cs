using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("TAX")]
public class TAX_DutyTaxFeeDetails : EdifactSegment
{
	[Position(1)]
	public string DutyTaxFeeFunctionQualifier { get; set; }

	[Position(2)]
	public C241_DutyTaxFeeType DutyTaxFeeType { get; set; }

	[Position(3)]
	public C533_DutyTaxFeeAccountDetail DutyTaxFeeAccountDetail { get; set; }

	[Position(4)]
	public string DutyTaxFeeAssessmentBasis { get; set; }

	[Position(5)]
	public C243_DutyTaxFeeDetail DutyTaxFeeDetail { get; set; }

	[Position(6)]
	public string DutyTaxFeeCategoryCoded { get; set; }

	[Position(7)]
	public string PartyTaxIdentificationNumber { get; set; }

	[Position(8)]
	public string CalculationSequenceIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TAX_DutyTaxFeeDetails>(this);
		validator.Required(x=>x.DutyTaxFeeFunctionQualifier);
		validator.Length(x => x.DutyTaxFeeFunctionQualifier, 1, 3);
		validator.Length(x => x.DutyTaxFeeAssessmentBasis, 1, 15);
		validator.Length(x => x.DutyTaxFeeCategoryCoded, 1, 3);
		validator.Length(x => x.PartyTaxIdentificationNumber, 1, 20);
		validator.Length(x => x.CalculationSequenceIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
