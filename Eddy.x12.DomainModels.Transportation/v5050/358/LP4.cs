using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Transportation.v5050._358;

public class LP4 {
	[SectionPosition(1)] public P4_PortInformation PortInformation { get; set; } = new();
	[SectionPosition(2)] public List<LP4_LVID> LVID {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.PortInformation);
		validator.CollectionSize(x => x.LVID, 0, 9999);
		foreach (var item in LVID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
