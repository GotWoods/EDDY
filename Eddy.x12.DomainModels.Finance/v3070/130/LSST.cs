using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._130;

public class LSST {
	[SectionPosition(1)] public SST_StudentAcademicStatus StudentAcademicStatus { get; set; } = new();
	[SectionPosition(2)] public List<SSE_EntryAndExitInformation> EntryAndExitInformation { get; set; } = new();
	[SectionPosition(3)] public N1_Name? Name { get; set; }
	[SectionPosition(4)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSST>(this);
		validator.Required(x => x.StudentAcademicStatus);
		validator.CollectionSize(x => x.EntryAndExitInformation, 0, 1000);
		return validator.Results;
	}
}
