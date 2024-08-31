using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup15_SegmentGroup27 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup15__SegmentGroup27_SegmentGroup28> SegmentGroup28 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup15__SegmentGroup27_SegmentGroup29> SegmentGroup29 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15_SegmentGroup27>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup28, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup29, 0, 9);
		foreach (var item in SegmentGroup28) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup29) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
