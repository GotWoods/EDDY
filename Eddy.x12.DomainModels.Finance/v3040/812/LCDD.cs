using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._812;

public class LCDD {
	[SectionPosition(1)] public CDD_CreditDebitAdjustmentDetail CreditDebitAdjustmentDetail { get; set; } = new();
	[SectionPosition(2)] public LIN_ItemIdentification? ItemIdentification { get; set; }
	[SectionPosition(3)] public PO4_ItemPhysicalDetails? ItemPhysicalDetails { get; set; }
	[SectionPosition(4)] public List<SAC_ServicePromotionAllowanceOrChargeInformation> ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(5)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(7)] public List<LCDD_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDD>(this);
		validator.Required(x => x.CreditDebitAdjustmentDetail);
		validator.CollectionSize(x => x.ServicePromotionAllowanceOrChargeInformation, 0, 25);
		validator.CollectionSize(x => x.ReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.LLM, 0, 10);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
