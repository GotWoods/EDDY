using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._872;

public class LNM1__LLRQ_LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(4)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(5)] public MSG_MessageText? MessageText { get; set; }
	[SectionPosition(6)] public N10_QuantityAndDescription? QuantityAndDescription { get; set; }
	[SectionPosition(7)] public BFS_BorrowerFinancialSummary? BorrowerFinancialSummary { get; set; }
	[SectionPosition(8)] public List<LNM1__LLRQ__LIN1_LSCM> LSCM {get;set;} = new();
	[SectionPosition(9)] public List<LNM1__LLRQ__LIN1_LNX1> LNX1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1__LLRQ_LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 1, 10);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 5);
		validator.CollectionSize(x => x.LSCM, 0, 10);
		validator.CollectionSize(x => x.LNX1, 0, 10);
		foreach (var item in LSCM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
