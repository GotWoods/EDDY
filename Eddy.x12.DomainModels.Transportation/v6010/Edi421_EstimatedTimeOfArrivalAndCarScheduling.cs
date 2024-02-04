using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;
using Eddy.x12.DomainModels.Transportation.v6010._421;

namespace Eddy.x12.DomainModels.Transportation.v6010;

public class Edi421_EstimatedTimeOfArrivalAndCarScheduling {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public IS1_EstimatedTimeOfArrivalAndCarScheduling EstimatedTimeOfArrivalAndCarScheduling { get; set; } = new();
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<ISC_InterlineServiceCommitmentDetail> InterlineServiceCommitmentDetail { get; set; } = new();
	[SectionPosition(5)] public N8_WaybillReference? WaybillReference { get; set; }
	[SectionPosition(6)] public List<IS2_ScheduledEvents> ScheduledEvents { get; set; } = new();
	[SectionPosition(7)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(8)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(9)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(10)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(11)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(12)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(13)] public H5_CarServiceOrder? CarServiceOrder { get; set; }
	[SectionPosition(14)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(15)] public IMA_InterchangeMoveAuthority? InterchangeMoveAuthority { get; set; }
	[SectionPosition(16)] public PS_ProtectiveServiceInstructions? ProtectiveServiceInstructions { get; set; }
	[SectionPosition(17)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(18)] public List<N8A_AdditionalReferenceInformation> AdditionalReferenceInformation { get; set; } = new();
	[SectionPosition(19)] public List<LS1> LS1 {get;set;} = new();
	[SectionPosition(20)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(21)] public List<LLH1> LLH1 {get;set;} = new();
	[SectionPosition(22)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(23)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(24)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi421_EstimatedTimeOfArrivalAndCarScheduling>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.EstimatedTimeOfArrivalAndCarScheduling);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 5);
		validator.CollectionSize(x => x.InterlineServiceCommitmentDetail, 1, 2147483647);
		validator.CollectionSize(x => x.ScheduledEvents, 1, 2147483647);
		validator.CollectionSize(x => x.PartyIdentification, 0, 10);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 5);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.AdditionalReferenceInformation, 0, 25);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LS1, 0, 12);
		validator.CollectionSize(x => x.LLH1, 0, 1000);
		foreach (var item in LS1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
