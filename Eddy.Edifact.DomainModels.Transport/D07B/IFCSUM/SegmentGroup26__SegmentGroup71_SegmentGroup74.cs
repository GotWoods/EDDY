using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07B;

namespace Eddy.Edifact.DomainModels.Transport.D07B.IFCSUM;

public class SegmentGroup26__SegmentGroup71_SegmentGroup74 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup71_SegmentGroup74>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
