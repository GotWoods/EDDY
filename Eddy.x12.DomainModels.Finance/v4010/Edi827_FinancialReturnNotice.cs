using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;
using Eddy.x12.DomainModels.Finance.v4010._827;

namespace Eddy.x12.DomainModels.Finance.v4010;

public class Edi827_FinancialReturnNotice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public RIC_FinancialReturn FinancialReturn { get; set; } = new();
	[SectionPosition(3)] public List<TRN_Trace> Trace { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public List<LNM1> LNM1 {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi827_FinancialReturnNotice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.FinancialReturn);
		validator.CollectionSize(x => x.Trace, 0, 2);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LNM1, 0, 10);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
