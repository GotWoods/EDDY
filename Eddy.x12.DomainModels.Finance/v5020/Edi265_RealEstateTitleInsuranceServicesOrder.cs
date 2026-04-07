using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;
using Eddy.x12.DomainModels.Finance.v5020._265;

namespace Eddy.x12.DomainModels.Finance.v5020;

public class Edi265_RealEstateTitleInsuranceServicesOrder {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(4)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(5)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(6)] public List<LTIS> LTIS {get;set;} = new();
	[SectionPosition(7)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi265_RealEstateTitleInsuranceServicesOrder>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.LN1, 1, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		validator.CollectionSize(x => x.LTIS, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTIS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
