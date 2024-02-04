using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._250;

public class L0100_L0110 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public G05_TotalShipmentInformation? TotalShipmentInformation { get; set; }
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100_L0110>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		return validator.Results;
	}
}
