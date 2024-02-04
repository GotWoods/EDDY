using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Transportation.v5050._453;

public class LSR_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<ISD_RailroadInterlineServiceDefinitionDetail> RailroadInterlineServiceDefinitionDetail { get; set; } = new();
	[SectionPosition(3)] public List<ISC_InterlineServiceCommitmentDetail> InterlineServiceCommitmentDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSR_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.RailroadInterlineServiceDefinitionDetail, 0, 15);
		validator.CollectionSize(x => x.InterlineServiceCommitmentDetail, 0, 999999);
		return validator.Results;
	}
}
