using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._880;

public class L0400 {
	[SectionPosition(1)] public ENT_Entity Entity { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<L0400_L0410> L0410 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400>(this);
		validator.Required(x => x.Entity);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.L0410, 1, 2147483647);
		foreach (var item in L0410) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
