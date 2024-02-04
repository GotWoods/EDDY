using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._437;

public class LJS {
	[SectionPosition(1)] public JS_RailJunctionSettlementRoleInformation RailJunctionSettlementRoleInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<SID_StandardTransportationCommodityCodeIdentification> StandardTransportationCommodityCodeIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LJS>(this);
		validator.Required(x => x.RailJunctionSettlementRoleInformation);
		validator.CollectionSize(x => x.DateTimeReference, 0, 3);
		validator.CollectionSize(x => x.StandardTransportationCommodityCodeIdentification, 0, 20);
		return validator.Results;
	}
}
