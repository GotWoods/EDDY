using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._324;

public class LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(3)] public ED_EquipmentDescription? EquipmentDescription { get; set; }
	[SectionPosition(4)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(5)] public V4_CargoLocationReference CargoLocationReference { get; set; } = new();
	[SectionPosition(6)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	[SectionPosition(7)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(8)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(9)] public List<H1_HazardousMaterial> HazardousMaterial { get; set; } = new();
	[SectionPosition(10)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 2);
		validator.Required(x => x.CargoLocationReference);
		validator.CollectionSize(x => x.PortOrTerminal, 0, 9);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.HazardousMaterial, 0, 4);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		return validator.Results;
	}
}
