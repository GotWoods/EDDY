using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;
using Eddy.x12.DomainModels.Transportation.v5040._326;

namespace Eddy.x12.DomainModels.Transportation.v5040;

public class Edi326_ConsignmentSummaryList {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LV1> LV1 {get;set;} = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi326_ConsignmentSummaryList>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LV1, 1, 999);
		foreach (var item in LV1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
