using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._872;

public class LNM1_LLRQ {
	[SectionPosition(1)] public LRQ_MortgageCharacteristicsRequested MortgageCharacteristicsRequested { get; set; } = new();
	[SectionPosition(2)] public LN1_LoanSpecificData LoanSpecificData { get; set; } = new();
	[SectionPosition(3)] public PRD_MortgageLoanProductDescription? MortgageLoanProductDescription { get; set; }
	[SectionPosition(4)] public List<MIC_MortgageInsuranceCoverage> MortgageInsuranceCoverage { get; set; } = new();
	[SectionPosition(5)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<PEX_PropertyOrHousingExpense> PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(8)] public List<RES_RealEstateSalesPriceChange> RealEstateSalesPriceChange { get; set; } = new();
	[SectionPosition(9)] public List<LNM1__LLRQ_LCDI> LCDI {get;set;} = new();
	[SectionPosition(10)] public List<LNM1__LLRQ_LSCM> LSCM {get;set;} = new();
	[SectionPosition(11)] public List<LNM1__LLRQ_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(12)] public List<LNM1__LLRQ_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(13)] public List<LNM1__LLRQ_LREA> LREA {get;set;} = new();
	[SectionPosition(14)] public List<LNM1__LLRQ_LMCD> LMCD {get;set;} = new();
	[SectionPosition(15)] public List<LNM1__LLRQ_LPRJ> LPRJ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LLRQ>(this);
		validator.Required(x => x.MortgageCharacteristicsRequested);
		validator.Required(x => x.LoanSpecificData);
		validator.CollectionSize(x => x.MortgageInsuranceCoverage, 0, 5);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyOrHousingExpense, 0, 20);
		validator.CollectionSize(x => x.RealEstateSalesPriceChange, 1, 2147483647);
		validator.CollectionSize(x => x.LCDI, 1, 2147483647);
		validator.CollectionSize(x => x.LSCM, 0, 10);
		validator.CollectionSize(x => x.LNX1, 0, 5);
		validator.CollectionSize(x => x.LIN1, 0, 12);
		foreach (var item in LCDI) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSCM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LMCD) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPRJ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
