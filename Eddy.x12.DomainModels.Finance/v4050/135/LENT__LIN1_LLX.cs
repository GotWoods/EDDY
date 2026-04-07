using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._135;

public class LENT__LIN1_LLX {
	[SectionPosition(1)] public LX_AssignedNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public N1_Name? PartyIdentification { get; set; }
	[SectionPosition(3)] public List<N3_AddressInformation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LIN1_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 3);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		return validator.Results;
	}
}
