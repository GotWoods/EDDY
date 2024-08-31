using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.IFCSUM;

public class SegmentGroup26_SegmentGroup39 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup26__SegmentGroup39_SegmentGroup40> SegmentGroup40 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup26__SegmentGroup39_SegmentGroup41> SegmentGroup41 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup26__SegmentGroup39_SegmentGroup42> SegmentGroup42 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup26__SegmentGroup39_SegmentGroup43> SegmentGroup43 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26_SegmentGroup39>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup40, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup41, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup42, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup43, 0, 99);
		foreach (var item in SegmentGroup40) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup41) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup42) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup43) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
