using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;
using Eddy.x12.DomainModels.Transportation.v6050._470;

namespace Eddy.x12.DomainModels.Transportation.v6050;

public class Edi470_RailroadClearance {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(5)] public D9_DestinationStation DestinationStation { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(8)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(9)] public List<LLET> LLET {get;set;} = new();
	[SectionPosition(10)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi470_RailroadClearance>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 10);
		validator.Required(x => x.OriginStation);
		validator.Required(x => x.DestinationStation);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 20);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLET, 0, 150);
		validator.CollectionSize(x => x.LN1, 0, 5);
		foreach (var item in LLET) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
