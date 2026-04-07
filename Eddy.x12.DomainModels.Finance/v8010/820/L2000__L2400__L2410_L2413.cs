using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._820;

public class L2000__L2400__L2410_L2413 {
	[SectionPosition(1)] public SLN_SublineItemDetail SublineItemDetail { get; set; } = new();
	[SectionPosition(2)] public List<L2000__L2400__L2410__L2413_L24131> L24131 {get;set;} = new();
	[SectionPosition(3)] public List<L2000__L2400__L2410__L2413_L24132> L24132 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2400__L2410_L2413>(this);
		validator.Required(x => x.SublineItemDetail);
		validator.CollectionSize(x => x.L24131, 1, 2147483647);
		validator.CollectionSize(x => x.L24132, 1, 2147483647);
		foreach (var item in L24131) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L24132) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
