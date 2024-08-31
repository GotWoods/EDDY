using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.MOVINS;

public class SegmentGroup6__SegmentGroup7__SegmentGroup8_SegmentGroup10 {
	[SectionPosition(1)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(2)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	[SectionPosition(3)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6__SegmentGroup7__SegmentGroup8_SegmentGroup10>(this);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.RangeDetails);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
