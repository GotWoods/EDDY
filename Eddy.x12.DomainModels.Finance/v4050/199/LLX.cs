using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._199;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public LRQ_MortgageCharacteristicsRequested? MortgageCharacteristicsRequested { get; set; }
	[SectionPosition(4)] public LN1_LoanSpecificData? LoanSpecificData { get; set; }
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(7)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(8)] public List<LLX_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(9)] public List<LLX_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(10)] public List<LLX_LFGS> LFGS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 12);
		validator.CollectionSize(x => x.DateTimeReference, 0, 2);
		validator.CollectionSize(x => x.Information, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.LNX1, 1, 2147483647);
		validator.CollectionSize(x => x.LIN1, 1, 2147483647);
		validator.CollectionSize(x => x.LFGS, 1, 2147483647);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFGS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
