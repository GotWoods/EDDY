using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._285;

public class LNX1__LLM__LLM_LTC2 {
	[SectionPosition(1)] public TC2_Commodity Commodity { get; set; } = new();
	[SectionPosition(2)] public H1_HazardousMaterial? HazardousMaterial { get; set; }
	[SectionPosition(3)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(4)] public List<LNX1__LLM__LLM__LTC2_LN4> LN4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNX1__LLM__LLM_LTC2>(this);
		validator.Required(x => x.Commodity);
		validator.CollectionSize(x => x.LN4, 1, 2147483647);
		foreach (var item in LN4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
