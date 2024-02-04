using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._460;

public class LSB__LSC_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public RS_RateSubset RateSubset { get; set; } = new();
	[SectionPosition(3)] public List<RD_RateData> RateData { get; set; } = new();
	[SectionPosition(4)] public List<LSB__LSC__LLX_LR9> LR9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSB__LSC_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.Required(x => x.RateSubset);
		validator.CollectionSize(x => x.RateData, 0, 25);
		validator.CollectionSize(x => x.LR9, 0, 2);
		foreach (var item in LR9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
