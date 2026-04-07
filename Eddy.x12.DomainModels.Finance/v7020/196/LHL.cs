using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._196;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public CRT_ContractorReportType? ContractorReportType { get; set; }
	[SectionPosition(3)] public BSD_BreakdownStructureDescription? BreakdownStructureDescription { get; set; }
	[SectionPosition(4)] public CLI_CostLineItem? CostLineItem { get; set; }
	[SectionPosition(5)] public CAL_Calendar? Calendar { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(8)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(9)] public List<RPA_RateAmountsOrPercents> RateAmountsOrPercents { get; set; } = new();
	[SectionPosition(10)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(11)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(12)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(13)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(14)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(15)] public List<LHL_LPD> LPD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.RateAmountsOrPercents, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.ProductItemDescription, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LPD, 1, 2147483647);
		foreach (var item in LPD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
