using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._130;

public class LLX_LSES {
	[SectionPosition(1)] public SES_AcademicSessionHeader AcademicSessionHeader { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public N1_Name? Name { get; set; }
	[SectionPosition(4)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<LLX__LSES_LSUM> LSUM {get;set;} = new();
	[SectionPosition(7)] public List<LLX__LSES_LCRS> LCRS {get;set;} = new();
	[SectionPosition(8)] public List<LLX__LSES_LDEG> LDEG {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LSES>(this);
		validator.Required(x => x.AcademicSessionHeader);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 50);
		validator.CollectionSize(x => x.LSUM, 0, 5);
		validator.CollectionSize(x => x.LCRS, 0, 50);
		validator.CollectionSize(x => x.LDEG, 0, 10);
		foreach (var item in LSUM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCRS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDEG) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
