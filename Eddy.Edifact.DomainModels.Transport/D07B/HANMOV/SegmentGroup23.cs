using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07B;

namespace Eddy.Edifact.DomainModels.Transport.D07B.HANMOV;

public class SegmentGroup23 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<EQN_NumberOfUnits> NumberOfUnits { get; set; } = new();
	[SectionPosition(3)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(4)] public List<EQA_AttachedEquipment> AttachedEquipment { get; set; } = new();
	[SectionPosition(5)] public List<RFF_Reference> Reference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup23>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.NumberOfUnits, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.AttachedEquipment, 1, 99);
		validator.CollectionSize(x => x.Reference, 1, 9);
		return validator.Results;
	}
}
