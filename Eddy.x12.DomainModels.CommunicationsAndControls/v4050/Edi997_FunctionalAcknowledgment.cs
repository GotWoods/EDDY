using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.CommunicationsAndControls.v4050._997;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v4050;

public class Edi997_FunctionalAcknowledgment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public AK1_FunctionalGroupResponseHeader FunctionalGroupResponseHeader { get; set; } = new();
	[SectionPosition(3)] public List<LAK2> LAK2 {get;set;} = new();
	[SectionPosition(4)] public AK9_FunctionalGroupResponseTrailer FunctionalGroupResponseTrailer { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi997_FunctionalAcknowledgment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.FunctionalGroupResponseHeader);
		validator.Required(x => x.FunctionalGroupResponseTrailer);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LAK2, 0, 999999);
		foreach (var item in LAK2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
