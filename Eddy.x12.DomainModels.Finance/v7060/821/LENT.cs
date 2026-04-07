using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._821;

public class LENT {
	[SectionPosition(1)] public ENT_Entity Entity { get; set; } = new();
	[SectionPosition(2)] public List<LENT_LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public List<LENT_LACT> LACT {get;set;} = new();
	[SectionPosition(4)] public List<LENT_LFA1> LFA1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT>(this);
		validator.Required(x => x.Entity);
		validator.CollectionSize(x => x.LN1, 0, 2);
		validator.CollectionSize(x => x.LACT, 1, 2147483647);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LACT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
