using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._205;

public class LMNC_LCDI {
	[SectionPosition(1)] public CDI_ChangeDetailInformation ChangeDetailInformation { get; set; } = new();
	[SectionPosition(2)] public List<LMNC__LCDI_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LMNC_LCDI>(this);
		validator.Required(x => x.ChangeDetailInformation);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
