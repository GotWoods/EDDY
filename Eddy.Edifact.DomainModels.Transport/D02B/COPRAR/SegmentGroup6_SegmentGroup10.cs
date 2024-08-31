using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D02B;

namespace Eddy.Edifact.DomainModels.Transport.D02B.COPRAR;

public class SegmentGroup6_SegmentGroup10 {
	[SectionPosition(1)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup6__SegmentGroup10_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup10>(this);
		validator.Required(x => x.TransportInformation);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 9);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
