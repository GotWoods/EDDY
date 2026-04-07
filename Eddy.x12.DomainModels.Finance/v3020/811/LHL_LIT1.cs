using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._811;

public class LHL_LIT1 {
	[SectionPosition(1)] public IT1_BaselineItemDataInvoice BaselineItemDataInvoice { get; set; } = new();
	[SectionPosition(2)] public List<SI_ServiceCharacteristicIdentification> ServiceCharacteristicIdentification { get; set; } = new();
	[SectionPosition(3)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(4)] public INC_InstallmentInformation? InstallmentInformation { get; set; }
	[SectionPosition(5)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(6)] public REF_ReferenceNumbers? ReferenceNumbers { get; set; }
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(9)] public List<LHL__LIT1_LQTY> LQTY {get;set;} = new();
	[SectionPosition(10)] public List<LHL__LIT1_LITA> LITA {get;set;} = new();
	[SectionPosition(11)] public List<LHL__LIT1_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LIT1>(this);
		validator.Required(x => x.BaselineItemDataInvoice);
		validator.CollectionSize(x => x.ServiceCharacteristicIdentification, 0, 2);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 10);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LQTY, 1, 2147483647);
		validator.CollectionSize(x => x.LITA, 0, 10);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LQTY) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LITA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
