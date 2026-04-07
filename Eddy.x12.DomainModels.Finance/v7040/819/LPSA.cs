using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._819;

public class LPSA {
	[SectionPosition(1)] public PSA_PartnerShareAccounting PartnerShareAccounting { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(3)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(7)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(8)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPSA>(this);
		validator.Required(x => x.PartnerShareAccounting);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		return validator.Results;
	}
}
