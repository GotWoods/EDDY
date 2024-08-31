using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.MOVINS;

public class SegmentGroup6__SegmentGroup7__SegmentGroup8_SegmentGroup11 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6__SegmentGroup7__SegmentGroup8_SegmentGroup11>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.Required(x => x.NameAndAddress);
		return validator.Results;
	}
}
