using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;
using Eddy.x12.DomainModels.Transportation.v6030._468;

namespace Eddy.x12.DomainModels.Transportation.v6030;

public class Edi468_RateDocketJournalLog {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public REN_RateRequestInformation RateRequestInformation { get; set; } = new();
	[SectionPosition(3)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi468_RateDocketJournalLog>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.RateRequestInformation);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 1, 100);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
