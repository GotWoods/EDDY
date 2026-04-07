using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._200;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	[SectionPosition(3)] public List<LLX_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(4)] public List<LLX_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(5)] public List<LLX_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.LIN1, 1, 15);
		validator.CollectionSize(x => x.LNX1, 1, 10);
		validator.CollectionSize(x => x.LN1, 0, 20);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
