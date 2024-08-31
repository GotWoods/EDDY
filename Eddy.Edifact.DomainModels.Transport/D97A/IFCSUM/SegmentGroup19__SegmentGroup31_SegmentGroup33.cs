using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A;

namespace Eddy.Edifact.DomainModels.Transport.D97A.IFCSUM;

public class SegmentGroup19__SegmentGroup31_SegmentGroup33 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup31_SegmentGroup33>(this);
		validator.Required(x => x.Reference);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
