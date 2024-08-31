using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19B;

namespace Eddy.Edifact.DomainModels.Transport.D19B.IFCSUM;

public class SegmentGroup28__SegmentGroup55__SegmentGroup62_SegmentGroup63 {
	[SectionPosition(1)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup55__SegmentGroup62_SegmentGroup63>(this);
		validator.Required(x => x.DocumentMessageDetails);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
