using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._820;

public class L2000__L2400_L2410 {
	[SectionPosition(1)] public IT1_BaselineItemDataInvoice BaselineItemDataInvoice { get; set; } = new();
	[SectionPosition(2)] public RPA_RateAmountsOrPercents? RateAmountsOrPercents { get; set; }
	[SectionPosition(3)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(4)] public List<L2000__L2400__L2410_L2411> L2411 {get;set;} = new();
	[SectionPosition(5)] public List<L2000__L2400__L2410_L2412> L2412 {get;set;} = new();
	[SectionPosition(6)] public List<L2000__L2400__L2410_L2413> L2413 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2400_L2410>(this);
		validator.Required(x => x.BaselineItemDataInvoice);
		validator.CollectionSize(x => x.L2411, 1, 2147483647);
		validator.CollectionSize(x => x.L2412, 1, 2147483647);
		validator.CollectionSize(x => x.L2413, 1, 2147483647);
		foreach (var item in L2411) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2412) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2413) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
