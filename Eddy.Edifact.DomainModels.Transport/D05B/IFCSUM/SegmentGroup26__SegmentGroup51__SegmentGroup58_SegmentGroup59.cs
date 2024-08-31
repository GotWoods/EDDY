using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.IFCSUM;

public class SegmentGroup26__SegmentGroup51__SegmentGroup58_SegmentGroup59 {
	[SectionPosition(1)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51__SegmentGroup58_SegmentGroup59>(this);
		validator.Required(x => x.DocumentMessageDetails);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
