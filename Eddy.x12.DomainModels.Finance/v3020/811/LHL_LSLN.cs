using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._811;

public class LHL_LSLN {
	[SectionPosition(1)] public SLN_SublineItemDetail SublineItemDetail { get; set; } = new();
	[SectionPosition(2)] public List<SI_ServiceCharacteristicIdentification> ServiceCharacteristicIdentification { get; set; } = new();
	[SectionPosition(3)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(4)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(5)] public INC_InstallmentInformation? InstallmentInformation { get; set; }
	[SectionPosition(6)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(7)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(8)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(9)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(10)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(11)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(12)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(13)] public List<LHL__LSLN_LQTY> LQTY {get;set;} = new();
	[SectionPosition(14)] public List<LHL__LSLN_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LSLN>(this);
		validator.Required(x => x.SublineItemDetail);
		validator.CollectionSize(x => x.ServiceCharacteristicIdentification, 0, 2);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 10);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 10);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceNumbers, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 10);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LQTY, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LQTY) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
