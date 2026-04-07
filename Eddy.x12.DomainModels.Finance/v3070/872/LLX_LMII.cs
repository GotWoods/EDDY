using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._872;

public class LLX_LMII {
	[SectionPosition(1)] public MII_MortgageInsuranceInformation MortgageInsuranceInformation { get; set; } = new();
	[SectionPosition(2)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(3)] public LRQ_MortgageCharacteristicsRequested MortgageCharacteristicsRequested { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<PEX_PropertyOrHousingExpense> PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(6)] public LN1_LoanSpecificData LoanSpecificData { get; set; } = new();
	[SectionPosition(7)] public List<RLD_DownPaymentData> DownPaymentData { get; set; } = new();
	[SectionPosition(8)] public PRD_MortgageLoanProductDescription MortgageLoanProductDescription { get; set; } = new();
	[SectionPosition(9)] public PAY_AdjustablePaymentDescription? AdjustablePaymentDescription { get; set; }
	[SectionPosition(10)] public RAT_AdjustableRateDescription? AdjustableRateDescription { get; set; }
	[SectionPosition(11)] public List<LLX__LMII_LREA> LREA {get;set;} = new();
	[SectionPosition(12)] public List<LLX__LMII_LMCD> LMCD {get;set;} = new();
	[SectionPosition(13)] public List<LLX__LMII_LBUY> LBUY {get;set;} = new();
	[SectionPosition(14)] public List<LLX__LMII_LPRJ> LPRJ {get;set;} = new();
	[SectionPosition(15)] public List<LLX__LMII_LPWK> LPWK {get;set;} = new();
	[SectionPosition(16)] public List<LLX__LMII_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(17)] public List<LLX__LMII_LIN1> LIN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LMII>(this);
		validator.Required(x => x.MortgageInsuranceInformation);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.Required(x => x.MortgageCharacteristicsRequested);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 5);
		validator.CollectionSize(x => x.PropertyOrHousingExpense, 0, 20);
		validator.Required(x => x.LoanSpecificData);
		validator.CollectionSize(x => x.DownPaymentData, 0, 5);
		validator.Required(x => x.MortgageLoanProductDescription);
		validator.CollectionSize(x => x.LBUY, 0, 20);
		validator.CollectionSize(x => x.LPWK, 0, 10);
		validator.CollectionSize(x => x.LNX1, 1, 5);
		validator.CollectionSize(x => x.LIN1, 1, 12);
		foreach (var item in LREA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LMCD) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LBUY) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPRJ) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPWK) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
