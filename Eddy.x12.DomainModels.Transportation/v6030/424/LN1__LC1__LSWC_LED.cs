using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._424;

public class LN1__LC1__LSWC_LED {
	[SectionPosition(1)] public ED_EquipmentDescription EquipmentDescription { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public SWD_SwitchingDetails? SwitchingDetails { get; set; }
	[SectionPosition(4)] public List<SWR_SwitchingRates> SwitchingRates { get; set; } = new();
	[SectionPosition(5)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(6)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(7)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(8)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1__LC1__LSWC_LED>(this);
		validator.Required(x => x.EquipmentDescription);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.SwitchingRates, 0, 2);
		return validator.Results;
	}
}
