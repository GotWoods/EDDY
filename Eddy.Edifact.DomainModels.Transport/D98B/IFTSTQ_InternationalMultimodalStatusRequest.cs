using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.DomainModels.Transport.D98B.IFTSTQ;

namespace Eddy.Edifact.DomainModels.Transport.D98B;

public class IFTSTQ_InternationalMultimodalStatusRequest {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(5)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(6)] public List<TDT_DetailsOfTransport> DetailsOfTransport { get; set; } = new();
	[SectionPosition(7)] public List<EQD_EquipmentDetails> EquipmentDetails { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup4> SegmentGroup4 {get;set;} = new();
	[SectionPosition(10)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<IFTSTQ_InternationalMultimodalStatusRequest>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 99);
		validator.CollectionSize(x => x.DetailsOfTransport, 1, 99);
		validator.CollectionSize(x => x.EquipmentDetails, 1, 999);
		validator.Required(x => x.MessageTrailer);
		

		validator.CollectionSize(x => x.SegmentGroup1, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup2, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup4, 0, 999);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
