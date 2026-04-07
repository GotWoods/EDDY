using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._824;

public class LOTI {
	[SectionPosition(1)] public OTI_OriginalTransactionIdentification OriginalTransactionIdentification { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(5)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(7)] public N1_Name? Name { get; set; }
	[SectionPosition(8)] public List<LOTI_LTED> LTED {get;set;} = new();
	[SectionPosition(9)] public List<LOTI_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LOTI>(this);
		validator.Required(x => x.OriginalTransactionIdentification);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 12);
		validator.CollectionSize(x => x.DateTimeReference, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 10);
		validator.CollectionSize(x => x.Quantity, 0, 10);
		validator.CollectionSize(x => x.LTED, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LTED) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
