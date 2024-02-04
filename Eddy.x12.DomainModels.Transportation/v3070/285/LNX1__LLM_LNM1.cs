using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._285;

public class LNX1__LLM_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(7)] public List<QTY_Quantity> Quantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNX1__LLM_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AddressInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		return validator.Results;
	}
}
