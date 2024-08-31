using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D12A;

namespace Eddy.Edifact.DomainModels.Transport.D12A.TPFREP;

public class SegmentGroup2 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup2_SegmentGroup3> SegmentGroup3 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup2>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Quantity, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup3, 0, 999);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
