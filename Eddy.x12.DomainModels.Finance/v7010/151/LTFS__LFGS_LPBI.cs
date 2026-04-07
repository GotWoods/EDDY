using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._151;

public class LTFS__LFGS_LPBI {
	[SectionPosition(1)] public PBI_ProblemIdentification ProblemIdentification { get; set; } = new();
	[SectionPosition(2)] public List<TIA_TaxInformationAndAmount> TaxInformationAndAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTFS__LFGS_LPBI>(this);
		validator.Required(x => x.ProblemIdentification);
		validator.CollectionSize(x => x.TaxInformationAndAmount, 0, 2);
		return validator.Results;
	}
}
