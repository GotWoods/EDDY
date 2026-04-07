using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;
using Eddy.x12.DomainModels.Finance.v7020._139;

namespace Eddy.x12.DomainModels.Finance.v7020;

public class Edi139_StudentLoanGuaranteeResult {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public GR_GuaranteeResultDetail GuaranteeResultDetail { get; set; } = new();
	[SectionPosition(4)] public List<DB_DisbursementInformation> DisbursementInformation { get; set; } = new();
	[SectionPosition(5)] public List<LLM> LLM {get;set;} = new();
	[SectionPosition(6)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(7)] public List<LAMT> LAMT {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi139_StudentLoanGuaranteeResult>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.GuaranteeResultDetail);
		validator.CollectionSize(x => x.DisbursementInformation, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LENT, 1, 6);
		validator.CollectionSize(x => x.LAMT, 0, 10);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
