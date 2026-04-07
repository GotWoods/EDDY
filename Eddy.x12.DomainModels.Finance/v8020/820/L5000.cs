using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._820;

public class L5000 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<TRN_Trace> Trace { get; set; } = new();
	[SectionPosition(4)] public List<L5000_L5100> L5100 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L5000>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Trace, 1, 2147483647);
		validator.CollectionSize(x => x.L5100, 1, 2147483647);
		foreach (var item in L5100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
