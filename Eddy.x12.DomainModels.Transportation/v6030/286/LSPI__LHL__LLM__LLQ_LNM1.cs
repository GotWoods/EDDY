using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._286;

public class LSPI__LHL__LLM__LLQ_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(8)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(9)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(10)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(11)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(12)] public List<TD5_CarrierDetailsRoutingSequenceTransitTime> CarrierDetailsRoutingSequenceTransitTime { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSPI__LHL__LLM__LLQ_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.CarrierDetailsRoutingSequenceTransitTime, 1, 2147483647);
		return validator.Results;
	}
}
