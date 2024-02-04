using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._858;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(3)] public NA_CrossReferenceEquipment? CrossReferenceEquipment { get; set; }
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(5)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(8)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(9)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	[SectionPosition(10)] public SL1_TariffReference? TariffReference2 { get; set; }
	[SectionPosition(11)] public List<N9_ReferenceIdentification> ReferenceIdentification2 { get; set; } = new();
	[SectionPosition(12)] public H3_SpecialHandlingInstructions? SpecialHandlingInstructions { get; set; }
	[SectionPosition(13)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(14)] public X2_ImportLicense? ImportLicense { get; set; }
	[SectionPosition(15)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(16)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(17)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(18)] public LHR_HazardousMaterialIdentifyingReferenceNumbers? HazardousMaterialIdentifyingReferenceNumbers { get; set; }
	[SectionPosition(19)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(20)] public List<Y7_Priority> Priority { get; set; } = new();
	[SectionPosition(21)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(22)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(23)] public LP_LoadPlanning? LoadPlanning { get; set; }
	[SectionPosition(24)] public List<AXL_VehicleAxleMeasurements> VehicleAxleMeasurements { get; set; } = new();
	[SectionPosition(25)] public List<LHL_LL0> LL0 {get;set;} = new();
	[SectionPosition(26)] public List<LHL_LLH1> LLH1 {get;set;} = new();
	[SectionPosition(27)] public List<LHL_LFA1> LFA1 {get;set;} = new();
	[SectionPosition(28)] public List<LHL_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(29)] public List<LHL_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 5);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 24);
		validator.CollectionSize(x => x.TariffReference, 0, 10);
		validator.CollectionSize(x => x.ReferenceIdentification2, 0, 10);
		validator.CollectionSize(x => x.ExportLicense, 0, 6);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 10);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 6);
		validator.CollectionSize(x => x.HazardousCertification, 0, 5);
		validator.CollectionSize(x => x.Priority, 0, 2);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		validator.CollectionSize(x => x.VehicleAxleMeasurements, 0, 12);
		validator.CollectionSize(x => x.LL0, 0, 20);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 0, 4);
		validator.CollectionSize(x => x.LN1, 0, 4);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
