using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._227;

public class L0100_L0110 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(3)] public G62_DateTime? DateTime { get; set; }
	[SectionPosition(4)] public TRL_EquipmentUsageInformation? EquipmentUsageInformation { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100_L0110>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 2);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 3);
		return validator.Results;
	}
}
