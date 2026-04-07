using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._195;

public class LCRC {
	[SectionPosition(1)] public CRC_ConditionsIndicator ConditionsIndicator { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRC>(this);
		validator.Required(x => x.ConditionsIndicator);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		return validator.Results;
	}
}
