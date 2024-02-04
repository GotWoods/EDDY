using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._110;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public P1_Pickup? Pickup { get; set; }
	[SectionPosition(4)] public R1_RouteInformationAir? RouteInformationAir { get; set; }
	[SectionPosition(5)] public POD_ProofOfDelivery? ProofOfDelivery { get; set; }
	[SectionPosition(6)] public V9_EventDetail? EventDetail { get; set; }
	[SectionPosition(7)] public List<RMT_RemittanceAdvice> RemittanceAdvice { get; set; } = new();
	[SectionPosition(8)] public G47_StatementIdentification? StatementIdentification { get; set; }
	[SectionPosition(9)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(10)] public List<LLX_LL5> LL5 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.RemittanceAdvice, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 2);
		validator.CollectionSize(x => x.LL5, 1, 4);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL5) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
