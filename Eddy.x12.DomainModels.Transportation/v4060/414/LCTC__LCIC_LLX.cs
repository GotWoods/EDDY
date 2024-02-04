using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._414;

public class LCTC__LCIC_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<CHR_CarHireRates> CarHireRates { get; set; } = new();
	[SectionPosition(3)] public List<CYC_CarHireCycle> CarHireCycle { get; set; } = new();
	[SectionPosition(4)] public PRI_ExternalReferenceIdentifier? ExternalReferenceIdentifier { get; set; }
	[SectionPosition(5)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(8)] public CV_CycleSummaryValue CycleSummaryValue { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCTC__LCIC_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.CarHireRates, 0, 3);
		validator.CollectionSize(x => x.CarHireCycle, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 2);
		validator.Required(x => x.CycleSummaryValue);
		return validator.Results;
	}
}
