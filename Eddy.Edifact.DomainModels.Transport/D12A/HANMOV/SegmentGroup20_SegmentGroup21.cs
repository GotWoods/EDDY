using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D12A;

namespace Eddy.Edifact.DomainModels.Transport.D12A.HANMOV;

public class SegmentGroup20_SegmentGroup21 {
	[SectionPosition(1)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup20_SegmentGroup21>(this);
		validator.Required(x => x.DocumentMessageDetails);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		return validator.Results;
	}
}
