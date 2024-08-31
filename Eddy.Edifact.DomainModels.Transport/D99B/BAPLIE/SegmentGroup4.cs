using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B;

namespace Eddy.Edifact.DomainModels.Transport.D99B.BAPLIE;

public class SegmentGroup4 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(5)] public FTX_FreeText FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 2);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 99);
		validator.Required(x => x.Reference);
		validator.Required(x => x.FreeText);
		return validator.Results;
	}
}
