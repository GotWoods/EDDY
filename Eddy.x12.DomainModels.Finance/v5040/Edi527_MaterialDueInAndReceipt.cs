using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;
using Eddy.x12.DomainModels.Finance.v5040._527;

namespace Eddy.x12.DomainModels.Finance.v5040;

public class Edi527_MaterialDueInAndReceipt {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BR_BeginningSegmentForMaterialManagement BeginningSegmentForMaterialManagement { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(5)] public List<LLM> LLM {get;set;} = new();
	[SectionPosition(6)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(7)] public List<LLIN> LLIN {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi527_MaterialDueInAndReceipt>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForMaterialManagement);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 5);
		

		validator.CollectionSize(x => x.LLM, 0, 50);
		validator.CollectionSize(x => x.LN1, 1, 20);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLIN, 1, 2147483647);
		foreach (var item in LLIN) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
