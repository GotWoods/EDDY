using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B;

namespace Eddy.Edifact.DomainModels.Transport.D99B.CODECO;

public class SegmentGroup2 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup2_SegmentGroup3> SegmentGroup3 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup2>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup3, 0, 9);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
