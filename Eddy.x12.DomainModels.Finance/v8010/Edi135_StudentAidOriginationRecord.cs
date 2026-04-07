using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;
using Eddy.x12.DomainModels.Finance.v8010._135;

namespace Eddy.x12.DomainModels.Finance.v8010;

public class Edi135_StudentAidOriginationRecord {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public DEF_DelayedRepayment? DelayedRepayment { get; set; }
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(5)] public GR_GuaranteeResultDetail? GuaranteeResultDetail { get; set; }
	[SectionPosition(6)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(7)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi135_StudentAidOriginationRecord>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		validator.CollectionSize(x => x.LENT, 1, 6);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
