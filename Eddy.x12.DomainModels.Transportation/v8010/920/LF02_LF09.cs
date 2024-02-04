using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._920;

public class LF02_LF09 {
	[SectionPosition(1)] public F09_DetailSupportingEvidenceForClaim DetailSupportingEvidenceForClaim { get; set; } = new();
	[SectionPosition(2)] public F04_WeightVolumeLoss? WeightVolumeLoss { get; set; }
	[SectionPosition(3)] public List<F05_AllowanceChargeClaim> AllowanceChargeClaim { get; set; } = new();
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LF02_LF09>(this);
		validator.Required(x => x.DetailSupportingEvidenceForClaim);
		validator.CollectionSize(x => x.AllowanceChargeClaim, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 9999);
		return validator.Results;
	}
}
