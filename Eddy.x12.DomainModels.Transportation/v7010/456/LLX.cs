using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._456;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(3)] public H5_CarServiceOrder? CarServiceOrder { get; set; }
	[SectionPosition(4)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(5)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(6)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(7)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(8)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(9)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(10)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(11)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(12)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(13)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(14)] public List<LLX_LS1> LS1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 99);
		validator.CollectionSize(x => x.PartyIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 15);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 36);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 30);
		validator.CollectionSize(x => x.LS1, 0, 12);
		foreach (var item in LS1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
