using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._423;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public XD_PlacementPullData? PlacementPullData { get; set; }
	[SectionPosition(3)] public List<LLX_LN7> LN7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.LN7, 0, 500);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
