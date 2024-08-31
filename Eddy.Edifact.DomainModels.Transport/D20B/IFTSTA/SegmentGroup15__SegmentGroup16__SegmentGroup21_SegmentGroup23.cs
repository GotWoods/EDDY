using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20B;

namespace Eddy.Edifact.DomainModels.Transport.D20B.IFTSTA;

public class SegmentGroup15__SegmentGroup16__SegmentGroup21_SegmentGroup23 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup15__SegmentGroup16__SegmentGroup21__SegmentGroup23_SegmentGroup24> SegmentGroup24 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15__SegmentGroup16__SegmentGroup21_SegmentGroup23>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup24, 0, 9);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
