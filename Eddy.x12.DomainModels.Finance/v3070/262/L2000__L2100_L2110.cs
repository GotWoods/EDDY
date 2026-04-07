using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._262;

public class L2000__L2100_L2110 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public API_ActivityOrProcessInformation? ActivityOrProcessInformation { get; set; }
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2100_L2110>(this);
		validator.Required(x => x.Measurements);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 4);
		return validator.Results;
	}
}
