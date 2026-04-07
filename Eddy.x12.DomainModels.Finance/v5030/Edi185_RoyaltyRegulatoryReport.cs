using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;
using Eddy.x12.DomainModels.Finance.v5030._185;

namespace Eddy.x12.DomainModels.Finance.v5030;

public class Edi185_RoyaltyRegulatoryReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(5)] public List<LLM> LLM {get;set;} = new();

	//Details
	[SectionPosition(6)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(7)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(8)] public List<LASM> LASM {get;set;} = new();
	[SectionPosition(9)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi185_RoyaltyRegulatoryReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		

		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LASM, 1, 2147483647);
		foreach (var item in LASM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
