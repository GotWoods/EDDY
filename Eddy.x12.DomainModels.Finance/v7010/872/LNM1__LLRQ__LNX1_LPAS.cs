using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._872;

public class LNM1__LLRQ__LNX1_LPAS {
	[SectionPosition(1)] public PAS_PropertyAppraisalSummary PropertyAppraisalSummary { get; set; } = new();
	[SectionPosition(2)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(4)] public List<LNM1__LLRQ__LNX1__LPAS_LREF> LREF {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1__LLRQ__LNX1_LPAS>(this);
		validator.Required(x => x.PropertyAppraisalSummary);
		validator.CollectionSize(x => x.PartyIdentification, 0, 2);
		validator.CollectionSize(x => x.MessageText, 0, 10);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
