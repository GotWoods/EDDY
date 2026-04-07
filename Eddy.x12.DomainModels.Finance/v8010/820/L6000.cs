using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._820;

public class L6000 {
	[SectionPosition(1)] public N9_ExtendedReferenceInformation ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<L6000_L6100> L6100 {get;set;} = new();
	[SectionPosition(4)] public List<L6000_L6200> L6200 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L6000>(this);
		validator.Required(x => x.ExtendedReferenceInformation);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.L6100, 1, 2147483647);
		validator.CollectionSize(x => x.L6200, 1, 2147483647);
		foreach (var item in L6100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L6200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
