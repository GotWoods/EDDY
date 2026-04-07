using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Finance.v5010._820;

public class LENT_LADX {
	[SectionPosition(1)] public ADX_Adjustment Adjustment { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(5)] public List<LENT__LADX_LREF> LREF {get;set;} = new();
	[SectionPosition(6)] public List<LENT__LADX_LIT1> LIT1 {get;set;} = new();
	[SectionPosition(7)] public List<LENT__LADX_LFA1> LFA1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT_LADX>(this);
		validator.Required(x => x.Adjustment);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		validator.CollectionSize(x => x.LIT1, 1, 2147483647);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIT1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
