using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3050._242;

public class LIIS_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public List<LIIS__LN1_LSTS> LSTS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIIS_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 10);
		validator.CollectionSize(x => x.LSTS, 1, 2147483647);
		foreach (var item in LSTS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
