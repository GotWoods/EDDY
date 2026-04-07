using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._189;

public class LIN1_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<LIN1__LN1_LEMS> LEMS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.LEMS, 0, 5);
		foreach (var item in LEMS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
