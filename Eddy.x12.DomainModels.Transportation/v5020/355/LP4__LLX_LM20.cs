using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Transportation.v5020._355;

public class LP4__LLX_LM20 {
	[SectionPosition(1)] public M20_PermitToTransferRequestDetails PermitToTransferRequestDetails { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LM20>(this);
		validator.Required(x => x.PermitToTransferRequestDetails);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
