using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._179;

public class LHL_LN9 {
	[SectionPosition(1)] public N9_ExtendedReferenceInformation ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(5)] public List<LHL__LN9_LQTY> LQTY {get;set;} = new();
	[SectionPosition(6)] public List<LHL__LN9_LLM> LLM {get;set;} = new();
	[SectionPosition(7)] public List<LHL__LN9_LNM1> LNM1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LN9>(this);
		validator.Required(x => x.ExtendedReferenceInformation);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.LQTY, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LQTY) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
