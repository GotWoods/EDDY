using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._872;

public class LNM1__LLRQ_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public List<LNM1__LLRQ__LNX1_LPAS> LPAS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1__LLRQ_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 30);
		validator.CollectionSize(x => x.LPAS, 1, 5);
		foreach (var item in LPAS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
