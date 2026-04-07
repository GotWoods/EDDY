using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;
using Eddy.x12.DomainModels.Finance.v8030._144;

namespace Eddy.x12.DomainModels.Finance.v8030;

public class Edi144_StudentLoanTransferAndStatusVerification {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public GR_GuaranteeResultDetail GuaranteeResultDetail { get; set; } = new();
	[SectionPosition(4)] public List<LV_LoanVerification> LoanVerification { get; set; } = new();
	[SectionPosition(5)] public List<DB_DisbursementInformation> DisbursementInformation { get; set; } = new();
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public IDB_IndebtednessForStudentLoans? IndebtednessForStudentLoans { get; set; }
	[SectionPosition(8)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(9)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi144_StudentLoanTransferAndStatusVerification>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.GuaranteeResultDetail);
		validator.CollectionSize(x => x.LoanVerification, 0, 25);
		validator.CollectionSize(x => x.DisbursementInformation, 0, 10);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LENT, 1, 10);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
