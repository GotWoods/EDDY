using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;
using Eddy.x12.DomainModels.Finance.v8040._205;

namespace Eddy.x12.DomainModels.Finance.v8040;

public class Edi205_MortgageNote {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(4)] public List<LNM1> LNM1 {get;set;} = new();

	//Details
	[SectionPosition(5)] public List<LMNC> LMNC {get;set;} = new();

	//Summary
	[SectionPosition(6)] public CTT_TransactionTotals? TransactionTotals { get; set; }
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi205_MortgageNote>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.LNM1, 1, 5);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LMNC, 1, 2147483647);
		foreach (var item in LMNC) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
