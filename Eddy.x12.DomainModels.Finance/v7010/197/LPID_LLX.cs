using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._197;

public class LPID_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public G86_SignatureIdentification? SignatureIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPID_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		return validator.Results;
	}
}
