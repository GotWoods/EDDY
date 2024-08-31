using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18B;

namespace Eddy.Edifact.DomainModels.Transport.D18B.IFCSUM;

public class SegmentGroup28__SegmentGroup75_SegmentGroup78 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup75_SegmentGroup78>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
