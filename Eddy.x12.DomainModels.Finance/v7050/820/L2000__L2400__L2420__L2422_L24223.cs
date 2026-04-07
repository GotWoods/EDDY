using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._820;

public class L2000__L2400__L2420__L2422_L24223 {
	[SectionPosition(1)] public SLN_SublineItemDetail SublineItemDetail { get; set; } = new();
	[SectionPosition(2)] public List<L2000__L2400__L2420__L2422__L24223_L242231> L242231 {get;set;} = new();
	[SectionPosition(3)] public List<L2000__L2400__L2420__L2422__L24223_L242232> L242232 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2400__L2420__L2422_L24223>(this);
		validator.Required(x => x.SublineItemDetail);
		validator.CollectionSize(x => x.L242231, 1, 2147483647);
		validator.CollectionSize(x => x.L242232, 1, 2147483647);
		foreach (var item in L242231) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L242232) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
