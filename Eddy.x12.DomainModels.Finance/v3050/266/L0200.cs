using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._266;

public class L0200 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<API_ActivityOrProcessInformation> ActivityOrProcessInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(5)] public AMT_MonetaryAmount? MonetaryAmount { get; set; }
	[SectionPosition(6)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(7)] public List<L0200_L0220> L0220 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ActivityOrProcessInformation, 0, 2);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 0, 2);
		validator.CollectionSize(x => x.L0210, 1, 2147483647);
		validator.CollectionSize(x => x.L0220, 1, 2147483647);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0220) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
