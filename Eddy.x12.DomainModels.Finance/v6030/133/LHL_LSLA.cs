using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._133;

public class LHL_LSLA {
	[SectionPosition(1)] public SLA_SchoolAccreditationAndLicensing SchoolAccreditationAndLicensing { get; set; } = new();
	[SectionPosition(2)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<LHL__LSLA_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LSLA>(this);
		validator.Required(x => x.SchoolAccreditationAndLicensing);
		validator.CollectionSize(x => x.FieldOfStudy, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
