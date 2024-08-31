using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05A;

namespace Eddy.Edifact.DomainModels.Transport.D05A.HANMOV;

public class SegmentGroup7_SegmentGroup8 {
	[SectionPosition(1)] public STS_Status Status { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup7__SegmentGroup8_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup7__SegmentGroup8_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7_SegmentGroup8>(this);
		validator.Required(x => x.Status);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
