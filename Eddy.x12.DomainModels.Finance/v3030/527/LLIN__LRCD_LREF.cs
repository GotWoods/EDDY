using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._527;

public class LLIN__LRCD_LREF {
	[SectionPosition(1)] public REF_ReferenceNumbers ReferenceNumbers { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public N1_Name? Name { get; set; }
	[SectionPosition(5)] public List<LLIN__LRCD__LREF_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN__LRCD_LREF>(this);
		validator.Required(x => x.ReferenceNumbers);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.LLM, 0, 50);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
