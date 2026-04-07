using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._824;

public class LOTI_LTED {
	[SectionPosition(1)] public TED_TechnicalErrorDescription TechnicalErrorDescription { get; set; } = new();
	[SectionPosition(2)] public List<CTX_Context> Context { get; set; } = new();
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(4)] public List<RED_RelatedData> RelatedData { get; set; } = new();
	[SectionPosition(5)] public List<LOTI__LTED_LREF> LREF {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LOTI_LTED>(this);
		validator.Required(x => x.TechnicalErrorDescription);
		validator.CollectionSize(x => x.Context, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		validator.CollectionSize(x => x.RelatedData, 0, 100);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
