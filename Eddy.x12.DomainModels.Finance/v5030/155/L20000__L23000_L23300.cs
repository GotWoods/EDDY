using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._155;

public class L20000__L23000_L23300 {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(4)] public List<L20000__L23000__L23300_L23310> L23310 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000_L23300>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.L23310, 1, 2147483647);
		foreach (var item in L23310) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
