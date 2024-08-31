using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08B;

namespace Eddy.Edifact.DomainModels.Transport.D08B.HANMOV;

public class SegmentGroup2 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup2_SegmentGroup3> SegmentGroup3 {get;set;} = new();
	[SectionPosition(4)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup2>(this);
		validator.Required(x => x.Reference);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
