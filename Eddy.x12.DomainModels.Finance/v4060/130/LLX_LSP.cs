using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._130;

public class LLX_LSP {
	[SectionPosition(1)] public SP_SpecialProgram SpecialProgram { get; set; } = new();
	[SectionPosition(2)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(3)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	[SectionPosition(6)] public List<LLX__LSP_LOPS> LOPS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LSP>(this);
		validator.Required(x => x.SpecialProgram);
		validator.CollectionSize(x => x.LOPS, 0, 10);
		foreach (var item in LOPS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
