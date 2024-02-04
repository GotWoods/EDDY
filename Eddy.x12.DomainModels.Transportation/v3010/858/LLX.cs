using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.Transportation.v3010._858;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(3)] public NA_CrossReferenceEquipment? CrossReferenceEquipment { get; set; }
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(5)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(7)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(8)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(9)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	[SectionPosition(10)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(11)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(12)] public X2_ImportLicense? ImportLicense { get; set; }
	[SectionPosition(13)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(14)] public List<LLX_LL0> LL0 {get;set;} = new();
	[SectionPosition(15)] public List<LLX_LLH1> LLH1 {get;set;} = new();
	[SectionPosition(16)] public List<LH5_HazardousMaterialShipmentContacts> HazardousMaterialShipmentContacts { get; set; } = new();
	[SectionPosition(17)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 5);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 24);
		validator.CollectionSize(x => x.TariffReference, 0, 10);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.ExportLicense, 0, 6);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 10);
		validator.CollectionSize(x => x.HazardousMaterialShipmentContacts, 0, 2);
		validator.CollectionSize(x => x.HazardousCertification, 0, 5);
		validator.CollectionSize(x => x.LL0, 0, 10);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
