using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Transportation.v7030._357;

public class LP4_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public M13_ManifestAmendmentDetails? ManifestAmendmentDetails { get; set; }
	[SectionPosition(3)] public M21_SupplementaryInBondInformation? SupplementaryInBondInformation { get; set; }
	[SectionPosition(4)] public M12_InBondIdentifyingInformation? InBondIdentifyingInformation { get; set; }
	[SectionPosition(5)] public N9_ExtendedReferenceInformation? ExtendedReferenceInformation { get; set; }
	[SectionPosition(6)] public N1_PartyIdentification? PartyIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		return validator.Results;
	}
}
