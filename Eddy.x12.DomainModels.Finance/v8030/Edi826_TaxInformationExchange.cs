using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;
using Eddy.x12.DomainModels.Finance.v8030._826;

namespace Eddy.x12.DomainModels.Finance.v8030;

public class Edi826_TaxInformationExchange {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTI_BeginningTaxInformation BeginningTaxInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<TIA_TaxInformationAndAmount> TaxInformationAndAmount { get; set; } = new();
	[SectionPosition(6)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(7)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(8)] public List<LTFS> LTFS {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi826_TaxInformationExchange>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningTaxInformation);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.TaxInformationAndAmount, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		

		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LTFS, 1, 2147483647);
		foreach (var item in LTFS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
