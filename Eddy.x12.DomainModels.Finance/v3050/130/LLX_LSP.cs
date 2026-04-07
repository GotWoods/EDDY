using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._130;

public class LLX_LSP {
	[SectionPosition(1)] public SP_SpecialEducationProgram SpecialEducationProgram { get; set; } = new();
	[SectionPosition(2)] public OP_OtherProgramsAndServices? OtherProgramsAndServices { get; set; }
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(5)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(7)] public SSE_EntryAndExitDates? EntryAndExitDates { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LSP>(this);
		validator.Required(x => x.SpecialEducationProgram);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 10);
		return validator.Results;
	}
}
