using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.IFCSUM;

public class SegmentGroup27__SegmentGroup46_SegmentGroup52 {
	[SectionPosition(1)] public TSR_TransportServiceRequirements TransportServiceRequirements { get; set; } = new();
	[SectionPosition(2)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(3)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27__SegmentGroup46_SegmentGroup52>(this);
		validator.Required(x => x.TransportServiceRequirements);
		validator.Required(x => x.Reference);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
