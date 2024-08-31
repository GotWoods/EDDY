using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05A;

namespace Eddy.Edifact.DomainModels.Transport.D05A.IFCSUM;

public class SegmentGroup26__SegmentGroup71_SegmentGroup73 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup71_SegmentGroup73>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
