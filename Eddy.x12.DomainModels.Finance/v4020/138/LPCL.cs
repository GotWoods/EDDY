using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._138;

public class LPCL {
	[SectionPosition(1)] public PCL_PreviousCollege PreviousCollege { get; set; } = new();
	[SectionPosition(2)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public SSE_EntryAndExitInformation? EntryAndExitInformation { get; set; }
	[SectionPosition(5)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	[SectionPosition(6)] public List<LPCL_LDEG> LDEG {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPCL>(this);
		validator.Required(x => x.PreviousCollege);
		validator.CollectionSize(x => x.FieldOfStudy, 1, 2147483647);
		validator.CollectionSize(x => x.LDEG, 0, 10);
		foreach (var item in LDEG) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
