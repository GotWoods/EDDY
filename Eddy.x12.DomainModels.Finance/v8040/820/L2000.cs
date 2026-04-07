using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._820;

public class L2000 {
	[SectionPosition(1)] public ENT_Entity Entity { get; set; } = new();
	[SectionPosition(2)] public List<L2000_L2100> L2100 {get;set;} = new();
	[SectionPosition(3)] public List<L2000_L2200> L2200 {get;set;} = new();
	[SectionPosition(4)] public List<L2000_L2300> L2300 {get;set;} = new();
	[SectionPosition(5)] public List<L2000_L2400> L2400 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000>(this);
		validator.Required(x => x.Entity);
		validator.CollectionSize(x => x.L2100, 1, 2147483647);
		validator.CollectionSize(x => x.L2200, 1, 2147483647);
		validator.CollectionSize(x => x.L2300, 1, 2147483647);
		validator.CollectionSize(x => x.L2400, 1, 2147483647);
		foreach (var item in L2100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2400) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
