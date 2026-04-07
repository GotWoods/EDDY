using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._820;

public class L2000__L2300__L2320_L2323 {
	[SectionPosition(1)] public SLN_SublineItemDetail SublineItemDetail { get; set; } = new();
	[SectionPosition(2)] public List<L2000__L2300__L2320__L2323_L23231> L23231 {get;set;} = new();
	[SectionPosition(3)] public List<L2000__L2300__L2320__L2323_L23232> L23232 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2300__L2320_L2323>(this);
		validator.Required(x => x.SublineItemDetail);
		validator.CollectionSize(x => x.L23231, 1, 2147483647);
		validator.CollectionSize(x => x.L23232, 1, 2147483647);
		foreach (var item in L23231) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23232) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
