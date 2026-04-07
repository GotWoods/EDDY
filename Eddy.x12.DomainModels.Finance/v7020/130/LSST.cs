using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._130;

public class LSST {
	[SectionPosition(1)] public SST_StudentAcademicStatus StudentAcademicStatus { get; set; } = new();
	[SectionPosition(2)] public List<SSE_EntryAndExitInformation> EntryAndExitInformation { get; set; } = new();
	[SectionPosition(3)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(4)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSST>(this);
		validator.Required(x => x.StudentAcademicStatus);
		validator.CollectionSize(x => x.EntryAndExitInformation, 0, 1000);
		return validator.Results;
	}
}
