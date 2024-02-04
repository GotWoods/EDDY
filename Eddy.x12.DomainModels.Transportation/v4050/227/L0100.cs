using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._227;

public class L0100 {
	[SectionPosition(1)] public N1_Name PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public List<N3_AddressInformation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<G61_Contact> Contact { get; set; } = new();
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public List<L0100_L0110> L0110 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.Contact, 0, 3);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 3);
		validator.CollectionSize(x => x.L0110, 1, 2147483647);
		foreach (var item in L0110) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
