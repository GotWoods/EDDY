using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;
using Eddy.x12.DomainModels.Finance.v3070._191;

namespace Eddy.x12.DomainModels.Finance.v3070;

public class Edi191_StudentLoanPreClaimsAndClaims {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi191_StudentLoanPreClaimsAndClaims>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LENT, 1, 10);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
