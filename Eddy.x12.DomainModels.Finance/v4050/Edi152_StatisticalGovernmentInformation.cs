using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.Finance.v4050._152;

namespace Eddy.x12.DomainModels.Finance.v4050;

public class Edi152_StatisticalGovernmentInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public PAM_PeriodAmount? PeriodAmount { get; set; }
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LGRI> LGRI {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi152_StatisticalGovernmentInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 1000);
		validator.CollectionSize(x => x.LGRI, 1, 100000);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LGRI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
