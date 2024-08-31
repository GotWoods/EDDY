using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.DomainModels.Transport.D99A.COPARN;

namespace Eddy.Edifact.DomainModels.Transport.D99A;

public class COPARN_ContainerAnnouncement {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(5)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(6)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(7)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup3> SegmentGroup3 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup5> SegmentGroup5 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup9> SegmentGroup9 {get;set;} = new();
	[SectionPosition(13)] public CNT_ControlTotal ControlTotal { get; set; } = new();
	[SectionPosition(14)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<COPARN_ContainerAnnouncement>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.Required(x => x.ControlTotal);
		validator.Required(x => x.MessageTrailer);
		

		validator.CollectionSize(x => x.SegmentGroup1, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup2, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup3, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup5, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 9999);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
