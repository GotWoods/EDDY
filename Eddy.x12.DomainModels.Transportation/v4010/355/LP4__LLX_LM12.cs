using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._355;

public class LP4__LLX_LM12 {
	[SectionPosition(1)] public M12_InBondIdentifyingInformation InBondIdentifyingInformation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(3)] public List<LP4__LLX__LM12_LP5> LP5 {get;set;} = new();
	[SectionPosition(4)] public List<LP4__LLX__LM12_LM21> LM21 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LM12>(this);
		validator.Required(x => x.InBondIdentifyingInformation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.LP5, 0, 5);
		foreach (var item in LP5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LM21) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
