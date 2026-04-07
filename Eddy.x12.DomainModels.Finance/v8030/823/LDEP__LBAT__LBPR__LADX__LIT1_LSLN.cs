using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._823;

public class LDEP__LBAT__LBPR__LADX__LIT1_LSLN {
	[SectionPosition(1)] public SLN_SublineItemDetail SublineItemDetail { get; set; } = new();
	[SectionPosition(2)] public List<LDEP__LBAT__LBPR__LADX__LIT1__LSLN_LREF> LREF {get;set;} = new();
	[SectionPosition(3)] public List<LDEP__LBAT__LBPR__LADX__LIT1__LSLN_LSAC> LSAC {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT__LBPR__LADX__LIT1_LSLN>(this);
		validator.Required(x => x.SublineItemDetail);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		validator.CollectionSize(x => x.LSAC, 1, 2147483647);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSAC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
