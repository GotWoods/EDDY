using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._819;

public class LJIL {
	[SectionPosition(1)] public JIL_LineItemDetailForTheOperatingExpenseStatement LineItemDetailForTheOperatingExpenseStatement { get; set; } = new();
	[SectionPosition(2)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(7)] public PSA_PartnerShareAccounting? PartnerShareAccounting { get; set; }
	[SectionPosition(8)] public List<LJIL_LJID> LJID {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LJIL>(this);
		validator.Required(x => x.LineItemDetailForTheOperatingExpenseStatement);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 99);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 12);
		validator.CollectionSize(x => x.MessageText, 0, 12);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 10);
		validator.CollectionSize(x => x.LJID, 0, 1000);
		foreach (var item in LJID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
