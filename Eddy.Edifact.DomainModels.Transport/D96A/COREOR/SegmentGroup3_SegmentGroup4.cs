using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.COREOR;

public class SegmentGroup3_SegmentGroup4 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<RFF_Reference> Reference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3_SegmentGroup4>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		return validator.Results;
	}
}
