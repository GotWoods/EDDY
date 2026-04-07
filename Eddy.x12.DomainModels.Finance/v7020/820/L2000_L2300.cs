using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._820;

public class L2000_L2300 {
	[SectionPosition(1)] public ADX_Adjustment Adjustment { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(5)] public List<L2000__L2300_L2310> L2310 {get;set;} = new();
	[SectionPosition(6)] public List<L2000__L2300_L2320> L2320 {get;set;} = new();
	[SectionPosition(7)] public List<L2000__L2300_L2330> L2330 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2300>(this);
		validator.Required(x => x.Adjustment);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.L2310, 1, 2147483647);
		validator.CollectionSize(x => x.L2320, 1, 2147483647);
		validator.CollectionSize(x => x.L2330, 1, 2147483647);
		foreach (var item in L2310) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2320) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2330) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
