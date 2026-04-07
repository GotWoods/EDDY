using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;
using Eddy.x12.DomainModels.Finance.v5020._245;

namespace Eddy.x12.DomainModels.Finance.v5020;

public class Edi245_RealEstateTaxServiceResponse {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<LNM1> LNM1 {get;set;} = new();

	//Details
	[SectionPosition(4)] public List<LHL> LHL {get;set;} = new();

	//Summary
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi245_RealEstateTaxServiceResponse>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LHL, 1, 2147483647);
		foreach (var item in LHL) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
