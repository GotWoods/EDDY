using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B;

namespace Eddy.Edifact.DomainModels.Transport.D97B.IFCSUM;

public class SegmentGroup19__SegmentGroup31_SegmentGroup32 {
	[SectionPosition(1)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup31_SegmentGroup32>(this);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		return validator.Results;
	}
}
