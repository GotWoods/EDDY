using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._202;

public class LN9_LDEX {
	[SectionPosition(1)] public DEX_DeliveryExecutionInformation DeliveryExecutionInformation { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public CN1_ContractInformation? ContractInformation { get; set; }
	[SectionPosition(4)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(5)] public List<INT_Interest> Interest { get; set; } = new();
	[SectionPosition(6)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(7)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(8)] public MPP_MortgagePoolProgram? MortgagePoolProgram { get; set; }
	[SectionPosition(9)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(10)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(11)] public List<LN9__LDEX_LASM> LASM {get;set;} = new();
	[SectionPosition(12)] public List<LN9__LDEX_LNM1> LNM1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9_LDEX>(this);
		validator.Required(x => x.DeliveryExecutionInformation);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 15);
		validator.CollectionSize(x => x.PercentAmounts, 0, 10);
		validator.CollectionSize(x => x.Interest, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 4);
		validator.CollectionSize(x => x.QuantityInformation, 0, 5);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 10);
		validator.CollectionSize(x => x.Information, 0, 15);
		validator.CollectionSize(x => x.LASM, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LASM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
