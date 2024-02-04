using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._240;

public class L2000_L2500 {
	[SectionPosition(1)] public N1_Name PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_AddressInformation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(6)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2500>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		return validator.Results;
	}
}
