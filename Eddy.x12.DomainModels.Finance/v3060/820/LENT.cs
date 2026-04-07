using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._820;

public class LENT {
	[SectionPosition(1)] public ENT_Entity Entity { get; set; } = new();
	[SectionPosition(2)] public List<LENT_LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public List<LENT_LADX> LADX {get;set;} = new();
	[SectionPosition(4)] public List<LENT_LRMR> LRMR {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT>(this);
		validator.Required(x => x.Entity);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LADX, 1, 2147483647);
		validator.CollectionSize(x => x.LRMR, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LADX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LRMR) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
