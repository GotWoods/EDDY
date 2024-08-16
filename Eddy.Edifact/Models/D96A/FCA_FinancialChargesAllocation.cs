using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("FCA")]
public class FCA_FinancialChargesAllocation : EdifactSegment
{
	[Position(1)]
	public string SettlementCoded { get; set; }

	[Position(2)]
	public C878_ChargeAllowanceAccount ChargeAllowanceAccount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FCA_FinancialChargesAllocation>(this);
		validator.Required(x=>x.SettlementCoded);
		validator.Length(x => x.SettlementCoded, 1, 3);
		return validator.Results;
	}
}
