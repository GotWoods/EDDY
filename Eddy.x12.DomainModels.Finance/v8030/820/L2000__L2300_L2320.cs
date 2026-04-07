using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._820;

public class L2000__L2300_L2320 {
	[SectionPosition(1)] public IT1_BaselineItemDataInvoice BaselineItemDataInvoice { get; set; } = new();
	[SectionPosition(2)] public RPA_RateAmountsOrPercents? RateAmountsOrPercents { get; set; }
	[SectionPosition(3)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(4)] public List<L2000__L2300__L2320_L2321> L2321 {get;set;} = new();
	[SectionPosition(5)] public List<L2000__L2300__L2320_L2322> L2322 {get;set;} = new();
	[SectionPosition(6)] public List<L2000__L2300__L2320_L2323> L2323 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2300_L2320>(this);
		validator.Required(x => x.BaselineItemDataInvoice);
		validator.CollectionSize(x => x.L2321, 1, 2147483647);
		validator.CollectionSize(x => x.L2322, 1, 2147483647);
		validator.CollectionSize(x => x.L2323, 1, 2147483647);
		foreach (var item in L2321) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2322) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2323) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
