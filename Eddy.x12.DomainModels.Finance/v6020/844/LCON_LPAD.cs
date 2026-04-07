using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._844;

public class LCON_LPAD {
	[SectionPosition(1)] public PAD_ProductAdjustmentDetail ProductAdjustmentDetail { get; set; } = new();
	[SectionPosition(2)] public LIN_ItemIdentification? ItemIdentification { get; set; }
	[SectionPosition(3)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<UIT_UnitDetail> UnitDetail { get; set; } = new();
	[SectionPosition(6)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(8)] public RCD_ReceivingConditions? ReceivingConditions { get; set; }
	[SectionPosition(9)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(10)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(11)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(12)] public SSS_ProductSpecialServices? ProductSpecialServices { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCON_LPAD>(this);
		validator.Required(x => x.ProductAdjustmentDetail);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 200);
		validator.CollectionSize(x => x.Measurements, 0, 40);
		validator.CollectionSize(x => x.UnitDetail, 0, 5);
		validator.CollectionSize(x => x.QuantityInformation, 0, 5);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 12);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		return validator.Results;
	}
}
