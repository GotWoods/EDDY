using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._309;

public class LP4__LLX__LVID_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<LP4__LLX__LVID__LN1_LN10> LN10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LVID_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.LN10, 0, 999);
		foreach (var item in LN10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
