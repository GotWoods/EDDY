using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._823;

public class LDEP__LBAT_LBPR {
	[SectionPosition(1)] public BPR_BeginningSegmentForPaymentOrderRemittanceAdvice BeginningSegmentForPaymentOrderRemittanceAdvice { get; set; } = new();
	[SectionPosition(2)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(3)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public AVA_FundsAvailability? FundsAvailability { get; set; }
	[SectionPosition(7)] public List<LDEP__LBAT__LBPR_LADX> LADX {get;set;} = new();
	[SectionPosition(8)] public List<LDEP__LBAT__LBPR_LN1> LN1 {get;set;} = new();
	[SectionPosition(9)] public List<LDEP__LBAT__LBPR_LRMR> LRMR {get;set;} = new();
	[SectionPosition(10)] public List<LDEP__LBAT__LBPR_LTXP> LTXP {get;set;} = new();
	[SectionPosition(11)] public List<LDEP__LBAT__LBPR_LDED> LDED {get;set;} = new();
	[SectionPosition(12)] public List<LDEP__LBAT__LBPR_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT_LBPR>(this);
		validator.Required(x => x.BeginningSegmentForPaymentOrderRemittanceAdvice);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.LADX, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 0, 200);
		validator.CollectionSize(x => x.LRMR, 1, 2147483647);
		validator.CollectionSize(x => x.LTXP, 1, 2147483647);
		validator.CollectionSize(x => x.LDED, 1, 2147483647);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LADX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LRMR) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTXP) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDED) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
