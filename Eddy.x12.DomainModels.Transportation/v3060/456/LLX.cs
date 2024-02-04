using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._456;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(3)] public H5_CarServiceOrder? CarServiceOrder { get; set; }
	[SectionPosition(4)] public G4_ScaleIdentification? ScaleIdentification { get; set; }
	[SectionPosition(5)] public G5_WeightInformation? WeightInformation { get; set; }
	[SectionPosition(6)] public List<IC_IntermodalChassisEquipment> IntermodalChassisEquipment { get; set; } = new();
	[SectionPosition(7)] public N8_WaybillReference? WaybillReference { get; set; }
	[SectionPosition(8)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(9)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(10)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(11)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(12)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(13)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(14)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(15)] public IS1_EstimatedTimeOfArrivalAndCarScheduling? EstimatedTimeOfArrivalAndCarScheduling { get; set; }
	[SectionPosition(16)] public List<ISC_InterlineServiceCommitmentDetail> InterlineServiceCommitmentDetail { get; set; } = new();
	[SectionPosition(17)] public List<IS2_ScheduledEvents> ScheduledEvents { get; set; } = new();
	[SectionPosition(18)] public List<LLX_LVC> LVC {get;set;} = new();
	[SectionPosition(19)] public List<LLX_LS1> LS1 {get;set;} = new();
	[SectionPosition(20)] public List<LLX_LER> LER {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.IntermodalChassisEquipment, 0, 2);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 99);
		validator.CollectionSize(x => x.Name, 0, 999999);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 20);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 15);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.InterlineServiceCommitmentDetail, 0, 99);
		validator.CollectionSize(x => x.ScheduledEvents, 0, 99);
		validator.CollectionSize(x => x.LVC, 0, 21);
		validator.CollectionSize(x => x.LS1, 0, 10);
		validator.CollectionSize(x => x.LER, 0, 99);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LS1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LER) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
