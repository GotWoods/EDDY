using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._203;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public MPP_MortgagePoolProgram? MortgagePoolProgram { get; set; }
	[SectionPosition(4)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(5)] public List<INT_Interest> Interest { get; set; } = new();
	[SectionPosition(6)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<LLX_LRLT> LRLT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 4);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 10);
		validator.CollectionSize(x => x.Interest, 0, 2);
		validator.CollectionSize(x => x.QuantityInformation, 0, 5);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.LRLT, 1, 2147483647);
		foreach (var item in LRLT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
