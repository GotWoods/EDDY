using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;
using Eddy.x12.DomainModels.Transportation.v8030._361;

namespace Eddy.x12.DomainModels.Transportation.v8030;

public class Edi361_CarrierInterchangeAgreementOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(3)] public List<LCI> LCI {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi361_CarrierInterchangeAgreementOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.PartyIdentification);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LCI, 1, 9999);
		foreach (var item in LCI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
