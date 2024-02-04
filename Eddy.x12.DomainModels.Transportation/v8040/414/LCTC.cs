using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._414;

public class LCTC {
	[SectionPosition(1)] public CTC_CarHireTransactionControl CarHireTransactionControl { get; set; } = new();
	[SectionPosition(2)] public List<LCTC_LCIC> LCIC {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCTC>(this);
		validator.Required(x => x.CarHireTransactionControl);
		validator.CollectionSize(x => x.LCIC, 1, 1000);
		foreach (var item in LCIC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
