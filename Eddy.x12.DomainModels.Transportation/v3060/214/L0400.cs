using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._214;

public class L0400 {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(2)] public Q5_StatusDetails? StatusDetails { get; set; }
	[SectionPosition(3)] public Q6_ShipmentDetails? ShipmentDetails { get; set; }
	[SectionPosition(4)] public M7_SealNumbers? SealNumbers { get; set; }
	[SectionPosition(5)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(6)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(7)] public List<L0400_L0410> L0410 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400>(this);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.L0410, 0, 9999);
		foreach (var item in L0410) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
