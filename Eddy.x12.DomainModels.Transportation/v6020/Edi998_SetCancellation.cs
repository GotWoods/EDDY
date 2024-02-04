using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020;

public class Edi998_SetCancellation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ZD_TransactionSetDeletionIDReasonAndSource TransactionSetDeletionIDReasonAndSource { get; set; } = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi998_SetCancellation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetDeletionIDReasonAndSource);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
