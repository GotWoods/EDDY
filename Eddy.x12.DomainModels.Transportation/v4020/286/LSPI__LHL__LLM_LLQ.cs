using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._286;

public class LSPI__LHL__LLM_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(6)] public PDL_PaymentDetails? PaymentDetails { get; set; }
	[SectionPosition(7)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(9)] public List<VEH_VehicleInformation> VehicleInformation { get; set; } = new();
	[SectionPosition(10)] public List<DVI_DynamicVehicleInformation> DynamicVehicleInformation { get; set; } = new();
	[SectionPosition(11)] public List<TC2_Commodity> Commodity { get; set; } = new();
	[SectionPosition(12)] public List<N12_EquipmentEnvironment> EquipmentEnvironment { get; set; } = new();
	[SectionPosition(13)] public List<H1_HazardousMaterial> HazardousMaterial { get; set; } = new();
	[SectionPosition(14)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(15)] public List<LSPI__LHL__LLM__LLQ_LNM1> LNM1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSPI__LHL__LLM_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.VehicleInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DynamicVehicleInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Commodity, 1, 2147483647);
		validator.CollectionSize(x => x.EquipmentEnvironment, 1, 2147483647);
		validator.CollectionSize(x => x.HazardousMaterial, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
