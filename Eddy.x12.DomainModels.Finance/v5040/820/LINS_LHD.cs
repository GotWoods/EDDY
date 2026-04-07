using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._820;

public class LINS_LHD {
	[SectionPosition(1)] public HD_HealthCoverage HealthCoverage { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<LINS__LHD_LRMR> LRMR {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LINS_LHD>(this);
		validator.Required(x => x.HealthCoverage);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LRMR, 1, 2147483647);
		foreach (var item in LRMR) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
