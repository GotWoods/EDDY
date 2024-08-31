using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09B;

namespace Eddy.Edifact.DomainModels.Transport.D09B.IFTSTA;

public class SegmentGroup13 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<CNT_ControlTotal> ControlTotal { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup13_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.ControlTotal, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 99);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
