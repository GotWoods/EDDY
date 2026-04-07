using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._823;

public class LDEP__LBAT__LBPR__LRMR_LADX {
	[SectionPosition(1)] public ADX_Adjustment Adjustment { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public List<LDEP__LBAT__LBPR__LRMR__LADX_LREF> LREF {get;set;} = new();
	[SectionPosition(5)] public List<LDEP__LBAT__LBPR__LRMR__LADX_LIT1> LIT1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT__LBPR__LRMR_LADX>(this);
		validator.Required(x => x.Adjustment);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		validator.CollectionSize(x => x.LIT1, 1, 2147483647);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIT1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
