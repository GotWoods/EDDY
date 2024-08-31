using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B;

namespace Eddy.Edifact.DomainModels.Transport.D96B.IFTDGN;

public class SegmentGroup6 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(5)] public List<SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup6_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup6_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.Required(x => x.HandlingInstructions);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 4);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 4);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 2);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 99);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
