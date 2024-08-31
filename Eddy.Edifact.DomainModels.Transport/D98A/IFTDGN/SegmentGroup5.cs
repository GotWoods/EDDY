using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A;

namespace Eddy.Edifact.DomainModels.Transport.D98A.IFTDGN;

public class SegmentGroup5 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		return validator.Results;
	}
}
