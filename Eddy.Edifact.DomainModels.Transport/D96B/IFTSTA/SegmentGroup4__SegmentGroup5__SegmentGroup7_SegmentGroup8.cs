using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B;

namespace Eddy.Edifact.DomainModels.Transport.D96B.IFTSTA;

public class SegmentGroup4__SegmentGroup5__SegmentGroup7_SegmentGroup8 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4__SegmentGroup5__SegmentGroup7_SegmentGroup8>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		return validator.Results;
	}
}
