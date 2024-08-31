using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07A;

namespace Eddy.Edifact.DomainModels.Transport.D07A.IFTSTQ;

public class SegmentGroup4_SegmentGroup5 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<TPL_TransportPlacement> TransportPlacement { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4_SegmentGroup5>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.TransportPlacement, 1, 9);
		return validator.Results;
	}
}
