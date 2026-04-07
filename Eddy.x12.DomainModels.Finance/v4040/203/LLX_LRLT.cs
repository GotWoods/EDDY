using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._203;

public class LLX_LRLT {
	[SectionPosition(1)] public RLT_RealEstateLoanType RealEstateLoanType { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public IRA_InvestorReportingActionCode? InvestorReportingActionCode { get; set; }
	[SectionPosition(5)] public List<INT_Interest> Interest { get; set; } = new();
	[SectionPosition(6)] public List<PRC_PaymentRateChange> PaymentRateChange { get; set; } = new();
	[SectionPosition(7)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(8)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	[SectionPosition(9)] public List<LLX__LRLT_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LRLT>(this);
		validator.Required(x => x.RealEstateLoanType);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 3);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 8);
		validator.CollectionSize(x => x.Interest, 0, 2);
		validator.CollectionSize(x => x.PaymentRateChange, 0, 3);
		validator.CollectionSize(x => x.LocationIDComponent, 0, 10);
		validator.CollectionSize(x => x.IndustryCode, 0, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
