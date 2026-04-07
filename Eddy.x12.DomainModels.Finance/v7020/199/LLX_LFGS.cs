using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._199;

public class LLX_LFGS {
	[SectionPosition(1)] public FGS_FormGroup FormGroup { get; set; } = new();
	[SectionPosition(2)] public List<LLX__LFGS_LAMT> LAMT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LFGS>(this);
		validator.Required(x => x.FormGroup);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
