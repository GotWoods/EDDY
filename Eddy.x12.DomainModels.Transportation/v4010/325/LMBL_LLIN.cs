using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._325;

public class LMBL_LLIN {
	[SectionPosition(1)] public LIN_ItemIdentification ItemIdentification { get; set; } = new();
	[SectionPosition(2)] public SN1_ItemDetailShipment ItemDetailShipment { get; set; } = new();
	[SectionPosition(3)] public PRF_PurchaseOrderReference? PurchaseOrderReference { get; set; }
	[SectionPosition(4)] public TD1_CarrierDetailsQuantityAndWeight CarrierDetailsQuantityAndWeight { get; set; } = new();
	[SectionPosition(5)] public List<LMBL__LLIN_LH1> LH1 {get;set;} = new();
	[SectionPosition(6)] public G20_ItemPackingDetail? ItemPackingDetail { get; set; }
	[SectionPosition(7)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(8)] public UIT_UnitDetail? UnitDetail { get; set; }
	[SectionPosition(9)] public N1_Name? Name { get; set; }
	[SectionPosition(10)] public L8_LineItemSubtotal? LineItemSubtotal { get; set; }
	[SectionPosition(11)] public C3_Currency? Currency { get; set; }
	[SectionPosition(12)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	[SectionPosition(13)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LMBL_LLIN>(this);
		validator.Required(x => x.ItemIdentification);
		validator.Required(x => x.ItemDetailShipment);
		validator.Required(x => x.CarrierDetailsQuantityAndWeight);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 10);
		validator.CollectionSize(x => x.PortOrTerminal, 0, 4);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.LH1, 0, 10);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
