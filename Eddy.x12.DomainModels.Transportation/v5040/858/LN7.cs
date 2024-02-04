using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._858;

public class LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EM_EquipmentCharacteristics? EquipmentCharacteristics { get; set; }
	[SectionPosition(3)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(5)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(6)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(7)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(8)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(9)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(10)] public List<GA_CanadianGrainInformation> CanadianGrainInformation { get; set; } = new();
	[SectionPosition(11)] public List<LN7_LE1> LE1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 30);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.DateTime, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 36);
		validator.CollectionSize(x => x.CanadianGrainInformation, 0, 15);
		validator.CollectionSize(x => x.LE1, 0, 2);
		foreach (var item in LE1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
