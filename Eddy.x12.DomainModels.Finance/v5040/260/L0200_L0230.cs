using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._260;

public class L0200_L0230 {
	[SectionPosition(1)] public FIS_MortgageLoanFiscalData MortgageLoanFiscalData { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public MSG_MessageText? MessageText { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0230>(this);
		validator.Required(x => x.MortgageLoanFiscalData);
		return validator.Results;
	}
}
