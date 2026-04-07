using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;
using Eddy.x12.DomainModels.Finance.v7060._813;

namespace Eddy.x12.DomainModels.Finance.v7060;

public class Edi813_ElectronicFilingOfTaxReturnData {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTI_BeginningTaxInformation BeginningTaxInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<TIA_TaxInformationAndAmount> TaxInformationAndAmount { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<TRN_Trace> Trace { get; set; } = new();
	[SectionPosition(7)] public List<BPR_BeginningSegmentForPaymentOrderRemittanceAdvice> BeginningSegmentForPaymentOrderRemittanceAdvice { get; set; } = new();
	[SectionPosition(8)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(9)] public List<LTFS> LTFS {get;set;} = new();

	//Summary
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi813_ElectronicFilingOfTaxReturnData>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningTaxInformation);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		validator.CollectionSize(x => x.TaxInformationAndAmount, 0, 1000);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.Trace, 0, 1000);
		validator.CollectionSize(x => x.BeginningSegmentForPaymentOrderRemittanceAdvice, 0, 1000);
		

		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LTFS, 0, 100000);
		foreach (var item in LTFS) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
