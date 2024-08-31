using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D12A;

namespace Eddy.Edifact.DomainModels.Transport.D12A.IFCSUM;

public class SegmentGroup27__SegmentGroup73_SegmentGroup76 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27__SegmentGroup73_SegmentGroup76>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
