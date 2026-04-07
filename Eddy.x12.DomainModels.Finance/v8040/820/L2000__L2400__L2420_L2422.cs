using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._820;

public class L2000__L2400__L2420_L2422 {
	[SectionPosition(1)] public IT1_BaselineItemDataInvoice BaselineItemDataInvoice { get; set; } = new();
	[SectionPosition(2)] public RPA_RateAmountsOrPercents? RateAmountsOrPercents { get; set; }
	[SectionPosition(3)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(4)] public List<L2000__L2400__L2420__L2422_L24221> L24221 {get;set;} = new();
	[SectionPosition(5)] public List<L2000__L2400__L2420__L2422_L24222> L24222 {get;set;} = new();
	[SectionPosition(6)] public List<L2000__L2400__L2420__L2422_L24223> L24223 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2400__L2420_L2422>(this);
		validator.Required(x => x.BaselineItemDataInvoice);
		validator.CollectionSize(x => x.L24221, 1, 2147483647);
		validator.CollectionSize(x => x.L24222, 1, 2147483647);
		validator.CollectionSize(x => x.L24223, 1, 2147483647);
		foreach (var item in L24221) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L24222) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L24223) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
