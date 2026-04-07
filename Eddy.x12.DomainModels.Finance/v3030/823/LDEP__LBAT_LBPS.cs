using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._823;

public class LDEP__LBAT_LBPS {
	[SectionPosition(1)] public BPS_BeginningSegmentForPaymentOrderRemittanceAdvice BeginningSegmentForPaymentOrderRemittanceAdvice { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public AVA_FundsAvailability? FundsAvailability { get; set; }
	[SectionPosition(6)] public List<LDEP__LBAT__LBPS_LN1> LN1 {get;set;} = new();
	[SectionPosition(7)] public List<LDEP__LBAT__LBPS_LRMT> LRMT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT_LBPS>(this);
		validator.Required(x => x.BeginningSegmentForPaymentOrderRemittanceAdvice);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 5);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 200);
		validator.CollectionSize(x => x.LRMT, 0, 10000);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LRMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
