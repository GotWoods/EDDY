using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;
using Eddy.x12.DomainModels.Transportation.v7030._920;

namespace Eddy.x12.DomainModels.Transportation.v7030;

public class Edi920_LossOrDamageClaimGeneralCommodities {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public F01_IdentificationOfClaimClaimantOriginated IdentificationOfClaimClaimantOriginated { get; set; } = new();
	[SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<CUR_Currency> Currency { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LF02> LF02 {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi920_LossOrDamageClaimGeneralCommodities>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.IdentificationOfClaimClaimantOriginated);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.Currency, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LF02, 1, 9999);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LF02) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
