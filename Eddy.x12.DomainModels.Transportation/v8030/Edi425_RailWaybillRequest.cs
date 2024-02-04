using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;
using Eddy.x12.DomainModels.Transportation.v8030._425;

namespace Eddy.x12.DomainModels.Transportation.v8030;

public class Edi425_RailWaybillRequest {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LZT> LZT {get;set;} = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi425_RailWaybillRequest>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LZT, 1, 255);
		foreach (var item in LZT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
