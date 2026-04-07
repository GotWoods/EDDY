using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._200;

public class LLX_LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(4)] public N10_QuantityAndDescription? QuantityAndDescription { get; set; }
	[SectionPosition(5)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	[SectionPosition(8)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 0, 10);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.QuantityInformation, 0, 15);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 20);
		return validator.Results;
	}
}
