using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._813;

public class LTFS {
	[SectionPosition(1)] public TFS_TaxForm TaxForm { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(5)] public List<LTFS_LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LTFS_LFGS> LFGS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTFS>(this);
		validator.Required(x => x.TaxForm);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 10);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.MessageText, 0, 1000);
		validator.CollectionSize(x => x.LN1, 0, 5);
		validator.CollectionSize(x => x.LFGS, 0, 100000);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFGS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
