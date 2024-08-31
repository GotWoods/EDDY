using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D12B;

namespace Eddy.Edifact.DomainModels.Transport.D12B.DESTIM;

public class SegmentGroup1 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public DIM_Dimensions Dimensions { get; set; } = new();
	[SectionPosition(3)] public List<IMD_ItemDescription> ItemDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup1>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.Required(x => x.Dimensions);
		validator.CollectionSize(x => x.ItemDescription, 1, 9);
		return validator.Results;
	}
}
