using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._189;

public class LSST {
	[SectionPosition(1)] public SST_StudentAcademicStatus StudentAcademicStatus { get; set; } = new();
	[SectionPosition(2)] public SSE_EntryAndExitInformation? EntryAndExitInformation { get; set; }
	[SectionPosition(3)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(4)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public COM_CommunicationContactInformation? CommunicationContactInformation { get; set; }
	[SectionPosition(7)] public List<SUM_AcademicSummary> AcademicSummary { get; set; } = new();
	[SectionPosition(8)] public MSG_MessageText? MessageText { get; set; }
	[SectionPosition(9)] public List<LSST_LSES> LSES {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSST>(this);
		validator.Required(x => x.StudentAcademicStatus);
		validator.CollectionSize(x => x.Name, 0, 2);
		validator.CollectionSize(x => x.AcademicSummary, 0, 5);
		validator.CollectionSize(x => x.LSES, 0, 20);
		foreach (var item in LSES) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
