using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A;

namespace Eddy.Edifact.DomainModels.Transport.D06A.TANSTA;

public class SegmentGroup2 {
	[SectionPosition(1)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	[SectionPosition(2)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(5)] public FTX_FreeText FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup2>(this);
		validator.Required(x => x.TransportInformation);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.Required(x => x.Reference);
		validator.Required(x => x.FreeText);
		return validator.Results;
	}
}
