using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040;

public class Edi980_FunctionalGroupTotals {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<BT1_BatchTotals> BatchTotals { get; set; } = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi980_FunctionalGroupTotals>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.CollectionSize(x => x.BatchTotals, 1, 10);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
