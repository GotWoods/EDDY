using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v5030._997;

public class LAK2 {
	[SectionPosition(1)] public AK2_TransactionSetResponseHeader TransactionSetResponseHeader { get; set; } = new();
	[SectionPosition(2)] public List<LAK2_LAK3> LAK3 {get;set;} = new();
	[SectionPosition(3)] public AK5_TransactionSetResponseTrailer TransactionSetResponseTrailer { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAK2>(this);
		validator.Required(x => x.TransactionSetResponseHeader);
		validator.Required(x => x.TransactionSetResponseTrailer);
		validator.CollectionSize(x => x.LAK3, 1, 2147483647);
		foreach (var item in LAK3) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
