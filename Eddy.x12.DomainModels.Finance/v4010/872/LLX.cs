using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._872;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public N1_Name Name { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public List<LLX_LLRQ> LLRQ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 12);
		validator.CollectionSize(x => x.LLRQ, 1, 2147483647);
		foreach (var item in LLRQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
