using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._429;

public class LRU2 {
	[SectionPosition(1)] public RU2_EmployingCarrierResponse EmployingCarrierResponse { get; set; } = new();
	[SectionPosition(2)] public RU3_EmployingCarrierClaimProfile? EmployingCarrierClaimProfile { get; set; }
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRU2>(this);
		validator.Required(x => x.EmployingCarrierResponse);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 2);
		return validator.Results;
	}
}
