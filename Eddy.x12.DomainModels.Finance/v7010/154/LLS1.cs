using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._154;

public class LLS1 {
	[SectionPosition(1)] public LS1_AssetItemIdentification AssetItemIdentification { get; set; } = new();
	[SectionPosition(2)] public LIN_ItemIdentification? ItemIdentification { get; set; }
	[SectionPosition(3)] public List<PO3_AdditionalItemDetail> AdditionalItemDetail { get; set; } = new();
	[SectionPosition(4)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(5)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(6)] public List<TAX_TaxReference> TaxReference { get; set; } = new();
	[SectionPosition(7)] public CDS_CaseDescription? CaseDescription { get; set; }
	[SectionPosition(8)] public CED_AdministrationOfJusticeEventDescription? AdministrationOfJusticeEventDescription { get; set; }
	[SectionPosition(9)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(10)] public List<PAM_PeriodAmount> PeriodAmount { get; set; } = new();
	[SectionPosition(11)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(12)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(13)] public List<LLS1_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLS1>(this);
		validator.Required(x => x.AssetItemIdentification);
		validator.CollectionSize(x => x.AdditionalItemDetail, 0, 25);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 1000);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		validator.CollectionSize(x => x.TaxReference, 1, 2147483647);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PeriodAmount, 0, 25);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 5);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
