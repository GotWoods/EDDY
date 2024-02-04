using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._325;

public class LMBL_LLIN {
	[SectionPosition(1)] public LIN_ItemIdentification ItemIdentification { get; set; } = new();
	[SectionPosition(2)] public SN1_ItemDetailShipment ItemDetailShipment { get; set; } = new();
	[SectionPosition(3)] public PRF_PurchaseOrderReference PurchaseOrderReference { get; set; } = new();
	[SectionPosition(4)] public TD1_CarrierDetailsQuantityAndWeight CarrierDetailsQuantityAndWeight { get; set; } = new();
	[SectionPosition(5)] public G20_ItemPackingDetail ItemPackingDetail { get; set; } = new();
	[SectionPosition(6)] public UIT_UnitDetail? UnitDetail { get; set; }
	[SectionPosition(7)] public N1_Name? Name { get; set; }
	[SectionPosition(8)] public L8_LineItemSubtotal? LineItemSubtotal { get; set; }
	[SectionPosition(9)] public C3_Currency? Currency { get; set; }
	[SectionPosition(10)] public List<R4_Port> Port { get; set; } = new();
	[SectionPosition(11)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LMBL_LLIN>(this);
		validator.Required(x => x.ItemIdentification);
		validator.Required(x => x.ItemDetailShipment);
		validator.Required(x => x.PurchaseOrderReference);
		validator.Required(x => x.CarrierDetailsQuantityAndWeight);
		validator.Required(x => x.ItemPackingDetail);
		validator.CollectionSize(x => x.Port, 0, 4);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		return validator.Results;
	}
}
