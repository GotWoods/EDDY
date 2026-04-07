using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;
using Eddy.x12.DomainModels.Finance.v4020._819;

namespace Eddy.x12.DomainModels.Finance.v4020;

public class Edi819_OperatingExpenseStatement {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BOS_BeginningSegmentForTheOperatingExpenseStatement BeginningSegmentForTheOperatingExpenseStatement { get; set; } = new();
	[SectionPosition(3)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<ITD_TermsOfSaleDeferredTermsOfSale> TermsOfSaleDeferredTermsOfSale { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(6)] public List<LJIL> LJIL {get;set;} = new();

	//Summary
	[SectionPosition(7)] public AMT_MonetaryAmount MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(9)] public TDS_TotalMonetaryValueSummary? TotalMonetaryValueSummary { get; set; }
	[SectionPosition(10)] public List<LPSA> LPSA {get;set;} = new();
	[SectionPosition(11)] public CTT_TransactionTotals TransactionTotals { get; set; } = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi819_OperatingExpenseStatement>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTheOperatingExpenseStatement);
		validator.CollectionSize(x => x.TermsOfSaleDeferredTermsOfSale, 0, 5);
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LJIL, 1, 10000);
		foreach (var item in LJIL) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.MonetaryAmount);
		validator.CollectionSize(x => x.Quantity, 0, 5);
		validator.Required(x => x.TransactionTotals);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LPSA, 0, 1000);
		foreach (var item in LPSA) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
