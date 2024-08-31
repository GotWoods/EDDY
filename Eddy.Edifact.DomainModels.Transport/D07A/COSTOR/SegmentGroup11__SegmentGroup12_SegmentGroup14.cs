using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07A;

namespace Eddy.Edifact.DomainModels.Transport.D07A.COSTOR;

public class SegmentGroup11__SegmentGroup12_SegmentGroup14 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup11__SegmentGroup12_SegmentGroup14>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		return validator.Results;
	}
}
