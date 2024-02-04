using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;
using Eddy.x12.DomainModels.Transportation.v5040._424;

namespace Eddy.x12.DomainModels.Transportation.v5040;

public class Edi424_RailCarrierServicesSettlement {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BSW_BeginningSegmentForCarrierServicesSettlement BeginningSegmentForCarrierServicesSettlement { get; set; } = new();
	[SectionPosition(3)] public CUR_Currency Currency { get; set; } = new();
	[SectionPosition(4)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi424_RailCarrierServicesSettlement>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarrierServicesSettlement);
		validator.Required(x => x.Currency);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 0, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
