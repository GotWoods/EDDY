using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.MOVINS;

public class SegmentGroup6_SegmentGroup7 {
	[SectionPosition(1)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup6__SegmentGroup7_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(5)] public CNT_ControlTotal ControlTotal { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup7>(this);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.Required(x => x.ControlTotal);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
