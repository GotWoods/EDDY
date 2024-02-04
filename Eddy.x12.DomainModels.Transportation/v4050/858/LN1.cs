using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._858;

public class LN1 {
	[SectionPosition(1)] public N1_Name PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_AddressInformation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 5);
		return validator.Results;
	}
}
