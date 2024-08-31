using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08A;

namespace Eddy.Edifact.DomainModels.Transport.D08A.IFCSUM;

public class SegmentGroup26__SegmentGroup51_SegmentGroup55 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51_SegmentGroup55>(this);
		validator.Required(x => x.Reference);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		return validator.Results;
	}
}
