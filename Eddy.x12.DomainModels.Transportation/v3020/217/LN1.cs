using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._217;

public class LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<N4_GeographicLocation> GeographicLocation { get; set; } = new();
	[SectionPosition(4)] public List<LN1_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.Geography, 0, 9999);
		validator.CollectionSize(x => x.GeographicLocation, 0, 9999);
		validator.CollectionSize(x => x.LLX, 0, 999999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
