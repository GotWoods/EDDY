using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._265;

public class LLX_LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(4)] public FPT_FinancialParticipation? FinancialParticipation { get; set; }
	[SectionPosition(5)] public List<LLX__LIN1_LN4> LN4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 0, 30);
		validator.CollectionSize(x => x.LN4, 1, 2147483647);
		foreach (var item in LN4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
