using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._811;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public List<LHL_LLX> LLX {get;set;} = new();
	[SectionPosition(3)] public List<LHL_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(4)] public List<LHL_LITA> LITA {get;set;} = new();
	[SectionPosition(5)] public List<LHL_LIT1> LIT1 {get;set;} = new();
	[SectionPosition(6)] public List<LHL_LSLN> LSLN {get;set;} = new();
	[SectionPosition(7)] public List<LHL_LTCD> LTCD {get;set;} = new();
	[SectionPosition(8)] public List<LHL_LUSD> LUSD {get;set;} = new();
	[SectionPosition(9)] public List<LHL_LIII> LIII {get;set;} = new();
	[SectionPosition(10)] public List<LHL_LFA1> LFA1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		validator.CollectionSize(x => x.LITA, 1, 2147483647);
		validator.CollectionSize(x => x.LIT1, 0, 999999);
		validator.CollectionSize(x => x.LSLN, 1, 2147483647);
		validator.CollectionSize(x => x.LTCD, 1, 2147483647);
		validator.CollectionSize(x => x.LUSD, 1, 2147483647);
		validator.CollectionSize(x => x.LIII, 1, 2147483647);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LITA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIT1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSLN) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTCD) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LUSD) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIII) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
