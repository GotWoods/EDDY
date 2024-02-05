using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3010._868;

public class LE10 {
	[SectionPosition(1)] public E10_TransactionSetGrouping TransactionSetGrouping { get; set; } = new();
	[SectionPosition(2)] public List<LE10_LE12> LE12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE10>(this);
		validator.Required(x => x.TransactionSetGrouping);
		validator.CollectionSize(x => x.LE12, 0, 3);
		foreach (var item in LE12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
