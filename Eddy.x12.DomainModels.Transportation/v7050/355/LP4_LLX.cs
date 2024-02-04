using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._355;

public class LP4_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<LP4__LLX_LM13> LM13 {get;set;} = new();
	[SectionPosition(3)] public List<LP4__LLX_LM11> LM11 {get;set;} = new();
	[SectionPosition(4)] public List<LP4__LLX_LN9> LN9 {get;set;} = new();
	[SectionPosition(5)] public List<LP4__LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LP4__LLX_LM12> LM12 {get;set;} = new();
	[SectionPosition(7)] public List<LP4__LLX_LM14> LM14 {get;set;} = new();
	[SectionPosition(8)] public List<LP4__LLX_LM15> LM15 {get;set;} = new();
	[SectionPosition(9)] public List<LP4__LLX_LM20> LM20 {get;set;} = new();
	[SectionPosition(10)] public List<LP4__LLX_LVID> LVID {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.LN9, 0, 999);
		validator.CollectionSize(x => x.LN1, 0, 25);
		validator.CollectionSize(x => x.LM12, 0, 9999);
		validator.CollectionSize(x => x.LM14, 0, 9999);
		validator.CollectionSize(x => x.LM15, 0, 9999);
		validator.CollectionSize(x => x.LM20, 0, 9999);
		validator.CollectionSize(x => x.LVID, 0, 999);
		foreach (var item in LM13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LM11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LM12) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LM14) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LM15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LM20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LVID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
