using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B;

namespace Eddy.Edifact.DomainModels.Transport.D98B.IFCSUM;

public class SegmentGroup19__SegmentGroup34_SegmentGroup38 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup34_SegmentGroup38>(this);
		validator.Required(x => x.Reference);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		return validator.Results;
	}
}
