using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;
using Eddy.x12.DomainModels.Finance.v3070._155;

namespace Eddy.x12.DomainModels.Finance.v3070;

public class Edi155_BusinessCreditReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<L10000> L10000 {get;set;} = new();

	//Details
	[SectionPosition(4)] public List<L20000> L20000 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi155_BusinessCreditReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.L10000, 1, 2);
		foreach (var item in L10000) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L20000, 1, 2147483647);
		foreach (var item in L20000) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
