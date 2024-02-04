using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._350;

public class LP4 {
	[SectionPosition(1)] public P4_PortOfDischargeInformation PortOfDischargeInformation { get; set; } = new();
	[SectionPosition(2)] public List<LP4_LX4> LX4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.PortOfDischargeInformation);
		validator.CollectionSize(x => x.LX4, 0, 999);
		foreach (var item in LX4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
