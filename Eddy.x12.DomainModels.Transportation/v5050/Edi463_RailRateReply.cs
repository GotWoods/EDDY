using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;
using Eddy.x12.DomainModels.Transportation.v5050._463;

namespace Eddy.x12.DomainModels.Transportation.v5050;

public class Edi463_RailRateReply {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public REN_RateRequestInformation RateRequestInformation { get; set; } = new();
	[SectionPosition(3)] public List<LDK> LDK {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi463_RailRateReply>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.RateRequestInformation);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LDK, 0, 300000);
		foreach (var item in LDK) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
