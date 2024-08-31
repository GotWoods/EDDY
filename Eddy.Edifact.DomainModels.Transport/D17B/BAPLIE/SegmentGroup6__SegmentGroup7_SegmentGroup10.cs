using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17B;

namespace Eddy.Edifact.DomainModels.Transport.D17B.BAPLIE;

public class SegmentGroup6__SegmentGroup7_SegmentGroup10 {
	[SectionPosition(1)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(2)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6__SegmentGroup7_SegmentGroup10>(this);
		validator.Required(x => x.AttachedEquipment);
		validator.Required(x => x.NameAndAddress);
		return validator.Results;
	}
}
