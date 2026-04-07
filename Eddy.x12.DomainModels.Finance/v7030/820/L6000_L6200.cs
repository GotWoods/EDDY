using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Finance.v7030._820;

public class L6000_L6200 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<L6000__L6200_L6210> L6210 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L6000_L6200>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.L6210, 1, 2147483647);
		foreach (var item in L6210) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
