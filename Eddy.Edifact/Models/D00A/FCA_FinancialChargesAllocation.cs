using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("FCA")]
public class FCA_FinancialChargesAllocation : EdifactSegment
{
	[Position(1)]
	public string SettlementMeansCode { get; set; }

	[Position(2)]
	public C878_ChargeAllowanceAccount ChargeAllowanceAccount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FCA_FinancialChargesAllocation>(this);
		validator.Required(x=>x.SettlementMeansCode);
		validator.Length(x => x.SettlementMeansCode, 1, 3);
		return validator.Results;
	}
}
