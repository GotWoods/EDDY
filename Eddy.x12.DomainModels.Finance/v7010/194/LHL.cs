using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._194;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public List<PAM_PeriodAmount> PeriodAmount { get; set; } = new();
	[SectionPosition(6)] public List<HSD_HealthCareServicesDelivery> HealthCareServicesDelivery { get; set; } = new();
	[SectionPosition(7)] public List<NX1_PropertyOrEntityIdentification> PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(8)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(9)] public List<LHL_LN9> LN9 {get;set;} = new();
	[SectionPosition(10)] public List<LHL_LPO1> LPO1 {get;set;} = new();
	[SectionPosition(11)] public List<LHL_LPPL> LPPL {get;set;} = new();
	[SectionPosition(12)] public List<LHL_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.PeriodAmount, 1, 2147483647);
		validator.CollectionSize(x => x.HealthCareServicesDelivery, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyOrEntityIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.LN9, 1, 2147483647);
		validator.CollectionSize(x => x.LPO1, 1, 2147483647);
		validator.CollectionSize(x => x.LPPL, 1, 2147483647);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPO1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPPL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
