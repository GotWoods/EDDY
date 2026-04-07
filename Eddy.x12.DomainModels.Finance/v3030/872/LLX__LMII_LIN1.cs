using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._872;

public class LLX__LMII_LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(4)] public N10_QuantityAndDescription? QuantityAndDescription { get; set; }
	[SectionPosition(5)] public BFS_BorrowerFinancialSummary? BorrowerFinancialSummary { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LMII_LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 1, 10);
		return validator.Results;
	}
}
