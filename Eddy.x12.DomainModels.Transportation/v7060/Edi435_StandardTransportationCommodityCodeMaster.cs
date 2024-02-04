using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;
using Eddy.x12.DomainModels.Transportation.v7060._435;

namespace Eddy.x12.DomainModels.Transportation.v7060;

public class Edi435_StandardTransportationCommodityCodeMaster {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LSID> LSID {get;set;} = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi435_StandardTransportationCommodityCodeMaster>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LSID, 1, 9999);
		foreach (var item in LSID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
