using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A;

namespace Eddy.Edifact.DomainModels.Transport.D97A.HANMOV;

public class SegmentGroup16 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(3)] public SEL_SealNumber SealNumber { get; set; } = new();
	[SectionPosition(4)] public List<EQA_AttachedEquipment> AttachedEquipment { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup16>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.Required(x => x.NumberOfUnits);
		validator.Required(x => x.SealNumber);
		validator.CollectionSize(x => x.AttachedEquipment, 1, 99);
		return validator.Results;
	}
}
