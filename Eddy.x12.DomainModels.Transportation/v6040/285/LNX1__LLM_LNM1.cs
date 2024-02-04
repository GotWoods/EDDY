using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._285;

public class LNX1__LLM_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(8)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNX1__LLM_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		return validator.Results;
	}
}
