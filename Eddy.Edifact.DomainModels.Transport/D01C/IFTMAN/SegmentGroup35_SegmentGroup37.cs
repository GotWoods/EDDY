using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.IFTMAN;

public class SegmentGroup35_SegmentGroup37 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup35_SegmentGroup37>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		return validator.Results;
	}
}
