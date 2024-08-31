using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.BAPLIE;

public class SegmentGroup3_SegmentGroup4 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<EQA_AttachedEquipment> AttachedEquipment { get; set; } = new();
	[SectionPosition(3)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3_SegmentGroup4>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.AttachedEquipment, 1, 9);
		validator.Required(x => x.NameAndAddress);
		return validator.Results;
	}
}
