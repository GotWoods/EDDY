using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01A;

namespace Eddy.Edifact.DomainModels.Transport.D01A.IFCSUM;

public class SegmentGroup25__SegmentGroup70_SegmentGroup73 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup70_SegmentGroup73>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
