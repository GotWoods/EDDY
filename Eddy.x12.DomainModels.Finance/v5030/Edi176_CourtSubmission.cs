using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;
using Eddy.x12.DomainModels.Finance.v5030._176;

namespace Eddy.x12.DomainModels.Finance.v5030;

public class Edi176_CourtSubmission {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<LFGS> LFGS {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi176_CourtSubmission>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LFGS, 1, 2147483647);
		foreach (var item in LFGS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
