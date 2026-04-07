using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._133;

public class LHL_LENM {
	[SectionPosition(1)] public ENM_SchoolEnrollmentData SchoolEnrollmentData { get; set; } = new();
	[SectionPosition(2)] public FOS_FieldOfStudy? FieldOfStudy { get; set; }
	[SectionPosition(3)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LENM>(this);
		validator.Required(x => x.SchoolEnrollmentData);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		return validator.Results;
	}
}
