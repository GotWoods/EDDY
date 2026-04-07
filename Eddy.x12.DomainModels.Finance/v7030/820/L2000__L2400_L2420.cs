using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Finance.v7030._820;

public class L2000__L2400_L2420 {
	[SectionPosition(1)] public ADX_Adjustment Adjustment { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public List<L2000__L2400__L2420_L2421> L2421 {get;set;} = new();
	[SectionPosition(5)] public List<L2000__L2400__L2420_L2422> L2422 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2400_L2420>(this);
		validator.Required(x => x.Adjustment);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.L2421, 1, 2147483647);
		validator.CollectionSize(x => x.L2422, 1, 2147483647);
		foreach (var item in L2421) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2422) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
