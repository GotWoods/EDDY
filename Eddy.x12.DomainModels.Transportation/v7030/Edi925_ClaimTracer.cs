using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;
using Eddy.x12.DomainModels.Transportation.v7030._925;

namespace Eddy.x12.DomainModels.Transportation.v7030;

public class Edi925_ClaimTracer {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LF10> LF10 {get;set;} = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi925_ClaimTracer>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LF10, 1, 99);
		foreach (var item in LF10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
