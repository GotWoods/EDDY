using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020._412;

public class LR12 {
	[SectionPosition(1)] public R12_WorkOrderInformation WorkOrderInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<LR12_LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LR12_LR13> LR13 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LR12>(this);
		validator.Required(x => x.WorkOrderInformation);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 6);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.LN1, 1, 4);
		validator.CollectionSize(x => x.LR13, 1, 50);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LR13) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
