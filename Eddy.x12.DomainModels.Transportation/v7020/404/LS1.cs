using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._404;

public class LS1 {
	[SectionPosition(1)] public S1_StopOffName StopOffName { get; set; } = new();
	[SectionPosition(2)] public List<S2_StopOffAddress> StopOffAddress { get; set; } = new();
	[SectionPosition(3)] public S9_StopOffStation? StopOffStation { get; set; }
	[SectionPosition(4)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(5)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(6)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(7)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(8)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LS1>(this);
		validator.Required(x => x.StopOffName);
		validator.CollectionSize(x => x.StopOffAddress, 0, 2);
		return validator.Results;
	}
}
