using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.Finance.v4050._201;

namespace Eddy.x12.DomainModels.Finance.v4050;

public class Edi201_ResidentialLoanApplication {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(4)] public List<LLRQ> LLRQ {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi201_ResidentialLoanApplication>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.LN1, 1, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLRQ, 1, 2147483647);
		foreach (var item in LLRQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
