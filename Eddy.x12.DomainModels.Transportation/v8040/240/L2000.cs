using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._240;

public class L2000 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<L2000_L2500> L2500 {get;set;} = new();
	[SectionPosition(3)] public List<L2000_L2600> L2600 {get;set;} = new();
	[SectionPosition(4)] public List<L2000_L2700> L2700 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.L2700, 1, 2147483647);
		foreach (var item in L2500) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2600) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2700) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
