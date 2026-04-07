using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;
using Eddy.x12.DomainModels.Finance.v7020._812;

namespace Eddy.x12.DomainModels.Finance.v7020;

public class Edi812_CreditDebitAdjustment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BCD_BeginningCreditDebitAdjustment BeginningCreditDebitAdjustment { get; set; } = new();
	[SectionPosition(3)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(6)] public List<ITD_TermsOfSaleDeferredTermsOfSale> TermsOfSaleDeferredTermsOfSale { get; set; } = new();
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public FOB_FOBRelatedInstructions? FOBRelatedInstructions { get; set; }
	[SectionPosition(9)] public List<SHD_ShipmentDetail> ShipmentDetail { get; set; } = new();
	[SectionPosition(10)] public List<SAC_ServicePromotionAllowanceOrChargeInformation> ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(11)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(12)] public List<LLM> LLM {get;set;} = new();
	[SectionPosition(13)] public List<LFA1> LFA1 {get;set;} = new();

	//Details
	[SectionPosition(14)] public List<LCDD> LCDD {get;set;} = new();
	[SectionPosition(15)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi812_CreditDebitAdjustment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningCreditDebitAdjustment);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.TermsOfSaleDeferredTermsOfSale, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.ShipmentDetail, 1, 2147483647);
		validator.CollectionSize(x => x.ServicePromotionAllowanceOrChargeInformation, 0, 25);
		

		validator.CollectionSize(x => x.LN1, 1, 200);
		validator.CollectionSize(x => x.LLM, 0, 10);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LCDD, 1, 2147483647);
		foreach (var item in LCDD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
