using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._150;

public class LTFS_LFGS {
	[SectionPosition(1)] public FGS_FormGroup FormGroup { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public List<LTFS__LFGS_LTRS> LTRS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTFS_LFGS>(this);
		validator.Required(x => x.FormGroup);
		validator.CollectionSize(x => x.LTRS, 1, 100000);
		foreach (var item in LTRS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
