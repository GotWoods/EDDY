using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;
using Eddy.x12.DomainModels.Finance.v7050._158;

namespace Eddy.x12.DomainModels.Finance.v7050;

public class Edi158_TaxJurisdictionSourcing {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(4)] public List<LDTP> LDTP {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi158_TaxJurisdictionSourcing>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.PartyIdentification, 1, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LDTP, 1, 2147483647);
		foreach (var item in LDTP) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
