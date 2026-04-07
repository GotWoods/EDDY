using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._821;

public class LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(3)] public List<LN1_LACT> LACT {get;set;} = new();
	[SectionPosition(4)] public List<LN1_LFIR> LFIR {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.LACT, 1, 2147483647);
		validator.CollectionSize(x => x.LFIR, 1, 2147483647);
		foreach (var item in LACT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFIR) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
