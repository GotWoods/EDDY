using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._811;

public class LN1_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceIdentification? ReferenceIdentification { get; set; }
	[SectionPosition(3)] public List<LN1__LLX_LAMT> LAMT {get;set;} = new();
	[SectionPosition(4)] public List<LN1__LLX_LITA> LITA {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		validator.CollectionSize(x => x.LITA, 1, 2147483647);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LITA) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
