using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.COREOR;

public class SegmentGroup12_SegmentGroup15 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup12__SegmentGroup15_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup12_SegmentGroup15>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 9);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
