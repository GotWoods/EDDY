using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;
using Eddy.x12.DomainModels.Transportation.v3050._421;

namespace Eddy.x12.DomainModels.Transportation.v3050;

public class Edi421_EstimatedTimeOfArrivalAndCarScheduling {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public IS1_EstimatedTimeOfArrivalAndCarScheduling EstimatedTimeOfArrivalAndCarScheduling { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<ISC_InterlineServiceCommitmentDetail> InterlineServiceCommitmentDetail { get; set; } = new();
	[SectionPosition(5)] public N8_WaybillReference? WaybillReference { get; set; }
	[SectionPosition(6)] public List<IS2_ScheduledEvents> ScheduledEvents { get; set; } = new();
	[SectionPosition(7)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(8)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(9)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(10)] public List<S9_StopOffStation> StopOffStation { get; set; } = new();
	[SectionPosition(11)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(12)] public L5_DescriptionMarksAndNumbers? DescriptionMarksAndNumbers { get; set; }
	[SectionPosition(13)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(14)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi421_EstimatedTimeOfArrivalAndCarScheduling>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.EstimatedTimeOfArrivalAndCarScheduling);
		validator.CollectionSize(x => x.ReferenceNumber, 1, 3);
		validator.CollectionSize(x => x.InterlineServiceCommitmentDetail, 1, 999999);
		validator.CollectionSize(x => x.ScheduledEvents, 1, 999999);
		validator.CollectionSize(x => x.Name, 0, 2);
		validator.CollectionSize(x => x.StopOffStation, 0, 5);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
