using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Finance.v3060._191;

namespace Eddy.x12.DomainModels.Finance.v3060;

public class Edi191_StudentLoanPreclaims {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public GR_GuaranteeResultDetail GuaranteeResultDetail { get; set; } = new();
	[SectionPosition(4)] public SLI_SpecificLoanInformation SpecificLoanInformation { get; set; } = new();
	[SectionPosition(5)] public DEF_DelayedRepayment? DefermentInformation { get; set; }
	[SectionPosition(6)] public List<DB_DisbursementInformation> DisbursementInformation { get; set; } = new();
	[SectionPosition(7)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(8)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(9)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi191_StudentLoanPreclaims>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.GuaranteeResultDetail);
		validator.Required(x => x.SpecificLoanInformation);
		validator.CollectionSize(x => x.DisbursementInformation, 0, 10);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LENT, 1, 6);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
