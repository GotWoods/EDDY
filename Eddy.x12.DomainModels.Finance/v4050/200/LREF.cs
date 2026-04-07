using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._200;

public class LREF {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<G32_SurveyQuestionResponse> SurveyQuestionResponse { get; set; } = new();
	[SectionPosition(3)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LREF>(this);
		validator.Required(x => x.ReferenceInformation);
		validator.CollectionSize(x => x.SurveyQuestionResponse, 1, 2147483647);
		return validator.Results;
	}
}
