using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;
using Eddy.x12.DomainModels.Finance.v7060._823;

namespace Eddy.x12.DomainModels.Finance.v7060;

public class Edi823_Lockbox {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();

	//Details
	[SectionPosition(5)] public List<LDEP> LDEP {get;set;} = new();

	//Summary
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi823_Lockbox>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.CollectionSize(x => x.DateTimeReference, 0, 2);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LDEP, 1, 100);
		foreach (var item in LDEP) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
