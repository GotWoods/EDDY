using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.Finance.v3010;

public class Edi827_FinancialReturnNotice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public RIC_FinancialReturn FinancialReturn { get; set; } = new();
	[SectionPosition(3)] public List<TRN_Trace> Trace { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi827_FinancialReturnNotice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.FinancialReturn);
		validator.CollectionSize(x => x.Trace, 0, 2);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 10);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
