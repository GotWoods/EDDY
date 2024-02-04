using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._109;

public class LR4 {
	[SectionPosition(1)] public R4_PortOrTerminal PortOrTerminal { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(4)] public List<LR4_LN9> LN9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LR4>(this);
		validator.Required(x => x.PortOrTerminal);
		validator.CollectionSize(x => x.DateTimeReference, 0, 15);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.CollectionSize(x => x.LN9, 0, 9999);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
