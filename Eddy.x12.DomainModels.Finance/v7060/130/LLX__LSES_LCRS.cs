using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._130;

public class LLX__LSES_LCRS {
	[SectionPosition(1)] public CRS_CourseRecord CourseRecord { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public CSU_SupplementalCourseData? SupplementalCourseData { get; set; }
	[SectionPosition(4)] public List<LUI_LanguageUse> LanguageUse { get; set; } = new();
	[SectionPosition(5)] public List<RAP_RequirementAttributeAndProficiency> RequirementAttributeAndProficiency { get; set; } = new();
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(8)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(9)] public List<LLX__LSES__LCRS_LMKS> LMKS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LSES_LCRS>(this);
		validator.Required(x => x.CourseRecord);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.LanguageUse, 0, 10);
		validator.CollectionSize(x => x.RequirementAttributeAndProficiency, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 50);
		validator.CollectionSize(x => x.LMKS, 0, 10);
		foreach (var item in LMKS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
