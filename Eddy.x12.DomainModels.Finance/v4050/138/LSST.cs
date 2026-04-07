using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._138;

public class LSST {
	[SectionPosition(1)] public SST_StudentAcademicStatus StudentAcademicStatus { get; set; } = new();
	[SectionPosition(2)] public SSE_EntryAndExitInformation? EntryAndExitInformation { get; set; }
	[SectionPosition(3)] public SUM_AcademicSummary? AcademicSummary { get; set; }
	[SectionPosition(4)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	[SectionPosition(5)] public List<RQS_RequestForInformation> RequestForInformation { get; set; } = new();
	[SectionPosition(6)] public List<LSST_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSST>(this);
		validator.Required(x => x.StudentAcademicStatus);
		validator.CollectionSize(x => x.FieldOfStudy, 1, 2147483647);
		validator.CollectionSize(x => x.RequestForInformation, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
