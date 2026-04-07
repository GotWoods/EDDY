using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;
using Eddy.x12.DomainModels.Finance.v3070._135;

namespace Eddy.x12.DomainModels.Finance.v3070;

public class Edi135_StudentLoanApplication {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<SLI_SpecificLoanInformation> SpecificLoanInformation { get; set; } = new();
	[SectionPosition(4)] public List<DB_DisbursementInformation> DisbursementInformation { get; set; } = new();
	[SectionPosition(5)] public DEF_DelayedRepayment? DelayedRepayment { get; set; }
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi135_StudentLoanApplication>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.SpecificLoanInformation, 1, 3);
		validator.CollectionSize(x => x.DisbursementInformation, 1, 10);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LENT, 1, 6);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
