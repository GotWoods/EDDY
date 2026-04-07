using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._151;

public class LTFS_LFGS {
	[SectionPosition(1)] public FGS_FormGroup FormGroup { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<LTFS__LFGS_LPBI> LPBI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTFS_LFGS>(this);
		validator.Required(x => x.FormGroup);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.LPBI, 0, 1000);
		foreach (var item in LPBI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
