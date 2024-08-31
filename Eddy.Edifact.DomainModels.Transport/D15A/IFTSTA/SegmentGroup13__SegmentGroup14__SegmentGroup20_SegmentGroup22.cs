using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15A;

namespace Eddy.Edifact.DomainModels.Transport.D15A.IFTSTA;

public class SegmentGroup13__SegmentGroup14__SegmentGroup20_SegmentGroup22 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup13__SegmentGroup14__SegmentGroup20__SegmentGroup22_SegmentGroup23> SegmentGroup23 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13__SegmentGroup14__SegmentGroup20_SegmentGroup22>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup23, 0, 9);
		foreach (var item in SegmentGroup23) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
