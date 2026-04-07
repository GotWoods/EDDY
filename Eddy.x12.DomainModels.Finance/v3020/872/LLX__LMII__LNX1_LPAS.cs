using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._872;

public class LLX__LMII__LNX1_LPAS {
	[SectionPosition(1)] public PAS_PropertyAppraisalSummary PropertyAppraisalSummary { get; set; } = new();
	[SectionPosition(2)] public N1_Name? Name { get; set; }
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LMII__LNX1_LPAS>(this);
		validator.Required(x => x.PropertyAppraisalSummary);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 10);
		validator.CollectionSize(x => x.MessageText, 0, 10);
		return validator.Results;
	}
}
