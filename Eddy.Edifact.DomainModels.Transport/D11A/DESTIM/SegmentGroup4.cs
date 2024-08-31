using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D11A;

namespace Eddy.Edifact.DomainModels.Transport.D11A.DESTIM;

public class SegmentGroup4 {
	[SectionPosition(1)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup4_SegmentGroup5> SegmentGroup5 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4>(this);
		validator.Required(x => x.TransportInformation);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup5, 0, 9);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
