using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.DomainModels.Transport.D99A.BAPLIE;

namespace Eddy.Edifact.DomainModels.Transport.D99A;

public class BAPLIE_BayplanStowagePlanOccupiedAndEmptyLocations {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup4> SegmentGroup4 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup5> SegmentGroup5 {get;set;} = new();
	[SectionPosition(8)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<BAPLIE_BayplanStowagePlanOccupiedAndEmptyLocations>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.Required(x => x.DateTimePeriod);
		validator.Required(x => x.MessageTrailer);
		

		validator.CollectionSize(x => x.SegmentGroup1, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup2, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup4, 0, 3);
		validator.CollectionSize(x => x.SegmentGroup5, 0, 9999);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
