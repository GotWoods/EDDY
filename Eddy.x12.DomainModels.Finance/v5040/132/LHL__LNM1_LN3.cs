using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._132;

public class LHL__LNM1_LN3 {
	[SectionPosition(1)] public N3_PartyLocation PartyLocation { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(3)] public List<COM_CommunicationContactInformation> CommunicationContactInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LNM1_LN3>(this);
		validator.Required(x => x.PartyLocation);
		validator.CollectionSize(x => x.CommunicationContactInformation, 1, 2147483647);
		return validator.Results;
	}
}
