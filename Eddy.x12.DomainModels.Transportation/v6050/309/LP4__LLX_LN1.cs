using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._309;

public class LP4__LLX_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(5)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(6)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(7)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		return validator.Results;
	}
}
