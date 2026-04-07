using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._527;

public class LLIN {
	[SectionPosition(1)] public LIN_ItemIdentification ItemIdentification { get; set; } = new();
	[SectionPosition(2)] public CS_ContractSummary? ContractSummary { get; set; }
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<LLIN_LRCD> LRCD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN>(this);
		validator.Required(x => x.ItemIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.LRCD, 1, 2147483647);
		foreach (var item in LRCD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
