using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi466_RateRequest {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<AC_MovementRateSetHeader> MovementRateSetHeader { get; set; } = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi466_RateRequest>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.CollectionSize(x => x.MovementRateSetHeader, 1, 25);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
