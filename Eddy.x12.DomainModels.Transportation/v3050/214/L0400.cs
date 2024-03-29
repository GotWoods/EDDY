using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._214;

public class L0400 {
	[SectionPosition(1)] public REF_ReferenceNumbers ReferenceNumbers { get; set; } = new();
	[SectionPosition(2)] public Q5_StatusDetails? StatusDetails { get; set; }
	[SectionPosition(3)] public M7_SealNumbers? SealNumbers { get; set; }
	[SectionPosition(4)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(5)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(6)] public List<L0400_L0410> L0410 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400>(this);
		validator.Required(x => x.ReferenceNumbers);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.L0410, 0, 9999);
		foreach (var item in L0410) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
