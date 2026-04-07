using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Finance.v3020._823;

namespace Eddy.x12.DomainModels.Finance.v3020;

public class Edi823_Lockbox {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<N1_Name> Name { get; set; } = new();

	//Details
	[SectionPosition(3)] public List<LDEP> LDEP {get;set;} = new();

	//Summary
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi823_Lockbox>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.CollectionSize(x => x.Name, 1, 2);
		

		validator.CollectionSize(x => x.LDEP, 1, 100);
		foreach (var item in LDEP) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
