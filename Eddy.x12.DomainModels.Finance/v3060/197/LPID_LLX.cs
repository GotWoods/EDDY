using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._197;

public class LPID_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public G86_Signature? Signature { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPID_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		return validator.Results;
	}
}
