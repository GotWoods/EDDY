using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._200;

public class LVAR {
	[SectionPosition(1)] public VAR_CreditFileVariation CreditFileVariation { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public IN1_IndividualIdentification? IndividualIdentification { get; set; }
	[SectionPosition(4)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(5)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(6)] public N10_QuantityAndDescription? QuantityAndDescription { get; set; }
	[SectionPosition(7)] public List<LVAR_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(8)] public List<LVAR_LN1> LN1 {get;set;} = new();
	[SectionPosition(9)] public List<LVAR_LSCM> LSCM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVAR>(this);
		validator.Required(x => x.CreditFileVariation);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 50);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 0, 10);
		validator.CollectionSize(x => x.LNX1, 0, 10);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LSCM, 1, 2147483647);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSCM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
