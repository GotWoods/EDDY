using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.Transportation.v3010._859;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public LS_LoopHeader LoopHeader { get; set; } = new();
	[SectionPosition(4)] public List<LLX_LLX> LLX {get;set;} = new();
	[SectionPosition(5)] public LE_LoopTrailer LoopTrailer { get; set; } = new();
	[SectionPosition(6)] public SL1_TariffReference? TariffReference { get; set; }
	[SectionPosition(7)] public R1_RouteInformationAir? RouteInformationAir { get; set; }
	[SectionPosition(8)] public LH_MixedHazardousCommodities? MixedHazardousCommodities { get; set; }
	[SectionPosition(9)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(10)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(11)] public X2_ImportLicense? ImportLicense { get; set; }
	[SectionPosition(12)] public P1_PickUp? PickUp { get; set; }
	[SectionPosition(13)] public POD_ProofOfDelivery? ProofOfDelivery { get; set; }
	[SectionPosition(14)] public FOB_FOBRelatedInstructions? FOBRelatedInstructions { get; set; }
	[SectionPosition(15)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(16)] public L8_LineItemSubtotal? LineItemSubtotal { get; set; }
	[SectionPosition(17)] public V9_EventDetail? EventDetail { get; set; }
	[SectionPosition(18)] public P2_Delivery? Delivery { get; set; }
	[SectionPosition(19)] public List<N7_EquipmentDetails> EquipmentDetails { get; set; } = new();
	[SectionPosition(20)] public List<LLX_LH1> LH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.Required(x => x.LoopHeader);
		validator.Required(x => x.LoopTrailer);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.ExportLicense, 0, 6);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 20);
		validator.CollectionSize(x => x.EquipmentDetails, 0, 5);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LH1, 0, 3);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
