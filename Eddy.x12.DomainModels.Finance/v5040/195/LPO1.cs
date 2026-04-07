using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._195;

public class LPO1 {
	[SectionPosition(1)] public PO1_BaselineItemData BaselineItemData { get; set; } = new();
	[SectionPosition(2)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(3)] public List<LPO1_LMEA> LMEA {get;set;} = new();
	[SectionPosition(4)] public List<LPO1_LREF> LREF {get;set;} = new();
	[SectionPosition(5)] public List<LPO1_LLM> LLM {get;set;} = new();
	[SectionPosition(6)] public List<LPO1_LN1> LN1 {get;set;} = new();
	[SectionPosition(7)] public List<LPO1_LCRC> LCRC {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPO1>(this);
		validator.Required(x => x.BaselineItemData);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LMEA, 1, 2147483647);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LCRC, 1, 2147483647);
		foreach (var item in LMEA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCRC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
