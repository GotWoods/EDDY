using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._215;

public class L0200__L0240_L0250 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<G61_Contact> Contact { get; set; } = new();
	[SectionPosition(7)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(8)] public List<X2_ImportLicense> ImportLicense { get; set; } = new();
	[SectionPosition(9)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0240_L0250>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.Contact, 0, 10);
		validator.CollectionSize(x => x.ExportLicense, 0, 10);
		validator.CollectionSize(x => x.ImportLicense, 0, 10);
		validator.CollectionSize(x => x.PortOrTerminal, 0, 10);
		return validator.Results;
	}
}
