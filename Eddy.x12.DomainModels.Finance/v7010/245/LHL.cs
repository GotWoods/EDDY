using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._245;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public LN_LoanInformation? LoanInformation { get; set; }
	[SectionPosition(3)] public MLA_MortgageLoanAuditInformation? MortgageLoanAuditInformation { get; set; }
	[SectionPosition(4)] public ASM_AmountAndSettlementMethod? AmountAndSettlementMethod { get; set; }
	[SectionPosition(5)] public TA_TaxAuthority? TaxAuthority { get; set; }
	[SectionPosition(6)] public PTS_PropertyTaxStatus? PropertyTaxStatus { get; set; }
	[SectionPosition(7)] public TII_TaxInstallmentInformation? TaxInstallmentInformation { get; set; }
	[SectionPosition(8)] public INC_InstallmentInformation? InstallmentInformation { get; set; }
	[SectionPosition(9)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(10)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(11)] public List<LHL_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(12)] public List<LHL_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(13)] public List<LHL_LTDT> LTDT {get;set;} = new();
	[SectionPosition(14)] public List<LHL_LAMT> LAMT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		validator.CollectionSize(x => x.LNX1, 1, 2147483647);
		validator.CollectionSize(x => x.LTDT, 1, 2147483647);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTDT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
