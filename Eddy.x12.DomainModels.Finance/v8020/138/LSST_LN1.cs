using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._138;

public class LSST_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<COM_CommunicationContactInformation> CommunicationContactInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSST_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.CommunicationContactInformation, 0, 5);
		return validator.Results;
	}
}
