using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._161;

public class LFAC {
	[SectionPosition(1)] public FAC_FacingDirection FacingDirection { get; set; } = new();
	[SectionPosition(2)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(3)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(4)] public PWK_Paperwork? Paperwork { get; set; }
	[SectionPosition(5)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFAC>(this);
		validator.Required(x => x.FacingDirection);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 5);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		return validator.Results;
	}
}
