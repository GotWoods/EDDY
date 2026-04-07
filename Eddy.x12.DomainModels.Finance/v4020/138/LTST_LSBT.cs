using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._138;

public class LTST_LSBT {
	[SectionPosition(1)] public SBT_Subtest Subtest { get; set; } = new();
	[SectionPosition(2)] public List<SRE_TestScores> TestScores { get; set; } = new();
	[SectionPosition(3)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(4)] public List<LTST__LSBT_LRAP> LRAP {get;set;} = new();
	[SectionPosition(5)] public List<LTST__LSBT_LSCA> LSCA {get;set;} = new();
	[SectionPosition(6)] public List<LTST__LSBT_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTST_LSBT>(this);
		validator.Required(x => x.Subtest);
		validator.CollectionSize(x => x.TestScores, 0, 5);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LRAP, 1, 2147483647);
		validator.CollectionSize(x => x.LSCA, 1, 2147483647);
		foreach (var item in LRAP) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSCA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
