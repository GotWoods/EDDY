using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._138;

public class LTST {
	[SectionPosition(1)] public TST_TestScoreRecord TestScoreRecord { get; set; } = new();
	[SectionPosition(2)] public List<LTST_LSBT> LSBT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTST>(this);
		validator.Required(x => x.TestScoreRecord);
		validator.CollectionSize(x => x.LSBT, 1, 2147483647);
		foreach (var item in LSBT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
