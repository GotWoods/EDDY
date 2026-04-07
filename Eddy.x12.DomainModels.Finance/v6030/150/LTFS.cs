using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._150;

public class LTFS {
	[SectionPosition(1)] public TFS_TaxForm TaxForm { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public MTX_Text? Text { get; set; }
	[SectionPosition(4)] public List<LTFS_LTRS> LTRS {get;set;} = new();
	[SectionPosition(5)] public List<LTFS_LFGS> LFGS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTFS>(this);
		validator.Required(x => x.TaxForm);
		validator.CollectionSize(x => x.LTRS, 1, 100000);
		validator.CollectionSize(x => x.LFGS, 1, 1000);
		foreach (var item in LTRS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFGS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
