using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;
using Eddy.x12.DomainModels.Finance.v6050._175;

namespace Eddy.x12.DomainModels.Finance.v6050;

public class Edi175_CourtAndLawEnforcementNotice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<LCDS> LCDS {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi175_CourtAndLawEnforcementNotice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LCDS, 1, 2147483647);
		foreach (var item in LCDS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
