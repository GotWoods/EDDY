using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A;

namespace Eddy.Edifact.DomainModels.Transport.D97A.IFTDGN;

public class SegmentGroup2 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup2>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 10);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 2);
		return validator.Results;
	}
}
