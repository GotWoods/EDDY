using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._189;

public class LPCL {
	[SectionPosition(1)] public PCL_PreviousCollege PreviousCollege { get; set; } = new();
	[SectionPosition(2)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public SSE_EntryAndExitInformation? EntryAndExitInformation { get; set; }
	[SectionPosition(5)] public SUM_AcademicSummary? AcademicSummary { get; set; }
	[SectionPosition(6)] public List<LPCL_LSES> LSES {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPCL>(this);
		validator.Required(x => x.PreviousCollege);
		validator.CollectionSize(x => x.LSES, 0, 1000);
		foreach (var item in LSES) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
