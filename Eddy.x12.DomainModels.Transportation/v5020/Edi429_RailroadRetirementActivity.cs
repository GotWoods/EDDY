using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;
using Eddy.x12.DomainModels.Transportation.v5020._429;

namespace Eddy.x12.DomainModels.Transportation.v5020;

public class Edi429_RailroadRetirementActivity {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<RU1_RetirementBoardDetail> RetirementBoardDetail { get; set; } = new();
	[SectionPosition(3)] public List<LRU2> LRU2 {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi429_RailroadRetirementActivity>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.CollectionSize(x => x.RetirementBoardDetail, 0, 999);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LRU2, 0, 999);
		foreach (var item in LRU2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
