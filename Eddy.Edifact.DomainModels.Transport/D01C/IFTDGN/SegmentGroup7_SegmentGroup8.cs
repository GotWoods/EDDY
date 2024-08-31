using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.IFTDGN;

public class SegmentGroup7_SegmentGroup8 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup7__SegmentGroup8_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7_SegmentGroup8>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 9);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
