using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;
using Eddy.x12.DomainModels.Transportation.v3050._414;

namespace Eddy.x12.DomainModels.Transportation.v3050;

public class Edi414_RailCarhireSettlements {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public LEQ_LeasedEquipmentInformation? LeasedEquipmentInformation { get; set; }
	[SectionPosition(3)] public List<LCTC> LCTC {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi414_RailCarhireSettlements>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LCTC, 1, 99);
		foreach (var item in LCTC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
