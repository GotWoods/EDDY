using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;

namespace Eddy.Edifact.DomainModels.Transport.D99A.IFCSUM;

public class SegmentGroup19_SegmentGroup31 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup19__SegmentGroup31_SegmentGroup32> SegmentGroup32 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup19__SegmentGroup31_SegmentGroup33> SegmentGroup33 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19_SegmentGroup31>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup33, 0, 9);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup33) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
