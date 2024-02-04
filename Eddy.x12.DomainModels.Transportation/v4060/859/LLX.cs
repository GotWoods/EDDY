using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._859;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(4)] public List<LLX_LL0> LL0 {get;set;} = new();
	[SectionPosition(5)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	[SectionPosition(6)] public SL1_TariffReference? TariffDetails { get; set; }
	[SectionPosition(7)] public R1_RouteInformationAir? RouteInformationAir { get; set; }
	[SectionPosition(8)] public LH_MixedHazardousCommodities? MixedHazardousCommodities { get; set; }
	[SectionPosition(9)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(10)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(11)] public X2_ImportLicense? ImportLicense { get; set; }
	[SectionPosition(12)] public P1_Pickup? Pickup { get; set; }
	[SectionPosition(13)] public POD_ProofOfDelivery? ProofOfDelivery { get; set; }
	[SectionPosition(14)] public FOB_FOBRelatedInstructions? FOBRelatedInstructions { get; set; }
	[SectionPosition(15)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(16)] public L8_LineItemSubtotal? LineItemSubtotal { get; set; }
	[SectionPosition(17)] public V9_EventDetail? EventDetail { get; set; }
	[SectionPosition(18)] public P2_DeliveryDateInformation? DeliveryDateInformation { get; set; }
	[SectionPosition(19)] public List<N7_EquipmentDetails> EquipmentDetails { get; set; } = new();
	[SectionPosition(20)] public List<LLX_LH1> LH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 10);
		validator.CollectionSize(x => x.TariffReference, 0, 10);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.ExportLicense, 0, 6);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 20);
		validator.CollectionSize(x => x.EquipmentDetails, 0, 5);
		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LL0, 0, 10);
		validator.CollectionSize(x => x.LH1, 0, 3);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
