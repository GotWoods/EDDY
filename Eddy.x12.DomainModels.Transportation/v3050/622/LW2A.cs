using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._622;

public class LW2A {
	[SectionPosition(1)] public W2A_EquipmentInformation EquipmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public M7_SealNumbers? SealNumbers { get; set; }
	[SectionPosition(5)] public Q5_StatusDetails? StatusDetails { get; set; }
	[SectionPosition(6)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	[SectionPosition(7)] public PRO_ProtectiveServiceInformation? ProtectiveServiceInformation { get; set; }
	[SectionPosition(8)] public V1_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(9)] public List<R4_Port> Port { get; set; } = new();
	[SectionPosition(10)] public List<LW2A_LN1> LN1 {get;set;} = new();
	[SectionPosition(11)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LW2A>(this);
		validator.Required(x => x.EquipmentInformation);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 10);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 30);
		validator.CollectionSize(x => x.Port, 0, 8);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 20);
		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
