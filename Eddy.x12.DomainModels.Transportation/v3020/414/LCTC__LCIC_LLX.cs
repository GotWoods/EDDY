using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._414;

public class LCTC__LCIC_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<CHR_CarHireRates> CarHireRates { get; set; } = new();
	[SectionPosition(3)] public List<CYC_CarHireCycle> CarHireCycle { get; set; } = new();
	[SectionPosition(4)] public PRI_ExternalReferenceIdentifier? ExternalReferenceIdentifier { get; set; }
	[SectionPosition(5)] public L7A_ContractReferenceIdentifier? ContractReferenceIdentifier { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(7)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(8)] public CV_CycleSummaryValue CycleSummaryValue { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCTC__LCIC_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.CarHireRates, 0, 3);
		validator.CollectionSize(x => x.CarHireCycle, 0, 2);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 2);
		validator.Required(x => x.CycleSummaryValue);
		return validator.Results;
	}
}
