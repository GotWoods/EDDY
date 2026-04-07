using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._200;

public class LLX_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(4)] public N10_QuantityAndDescription? QuantityAndDescription { get; set; }
	[SectionPosition(5)] public ARS_ApplicantResidenceSpecifics? ApplicantResidenceSpecifics { get; set; }
	[SectionPosition(6)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	[SectionPosition(7)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 20);
		return validator.Results;
	}
}
