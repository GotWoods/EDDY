using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09A;

namespace Eddy.Edifact.DomainModels.Transport.D09A.IFTCCA;

public class SegmentGroup23 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<EQN_NumberOfUnits> NumberOfUnits { get; set; } = new();
	[SectionPosition(3)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(4)] public List<RFF_Reference> Reference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup23>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.NumberOfUnits, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		return validator.Results;
	}
}
