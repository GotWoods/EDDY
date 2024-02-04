using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;
using Eddy.x12.DomainModels.Transportation.v6040._126;

namespace Eddy.x12.DomainModels.Transportation.v6040;

public class Edi126_VehicleApplicationAdvice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LBVA> LBVA {get;set;} = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi126_VehicleApplicationAdvice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LBVA, 1, 99);
		foreach (var item in LBVA) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
