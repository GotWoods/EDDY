using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._820;

public class L8000_L8200 {
	[SectionPosition(1)] public HD_HealthCoverage HealthCoverage { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<L8000__L8200_L8210> L8210 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L8000_L8200>(this);
		validator.Required(x => x.HealthCoverage);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.L8210, 1, 2147483647);
		foreach (var item in L8210) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
