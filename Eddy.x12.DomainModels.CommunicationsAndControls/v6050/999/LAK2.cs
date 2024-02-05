using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v6050._999;

public class LAK2 {
	[SectionPosition(1)] public AK2_TransactionSetResponseHeader TransactionSetResponseHeader { get; set; } = new();
	[SectionPosition(2)] public List<LAK2_LIK3> LIK3 {get;set;} = new();
	[SectionPosition(3)] public IK5_ImplementationTransactionSetResponseTrailer ImplementationTransactionSetResponseTrailer { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAK2>(this);
		validator.Required(x => x.TransactionSetResponseHeader);
		validator.Required(x => x.ImplementationTransactionSetResponseTrailer);
		validator.CollectionSize(x => x.LIK3, 1, 2147483647);
		foreach (var item in LIK3) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
