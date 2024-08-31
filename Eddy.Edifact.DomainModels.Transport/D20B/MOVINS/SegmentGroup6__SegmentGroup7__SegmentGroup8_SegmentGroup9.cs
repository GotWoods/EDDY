using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20B;

namespace Eddy.Edifact.DomainModels.Transport.D20B.MOVINS;

public class SegmentGroup6__SegmentGroup7__SegmentGroup8_SegmentGroup9 {
	[SectionPosition(1)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(2)] public TSR_TransportServiceRequirements TransportServiceRequirements { get; set; } = new();
	[SectionPosition(3)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6__SegmentGroup7__SegmentGroup8_SegmentGroup9>(this);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.Required(x => x.TransportServiceRequirements);
		validator.Required(x => x.TransportInformation);
		return validator.Results;
	}
}
