using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._200;

public class LVAR_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_RealEstatePropertyIDComponent> RealEstatePropertyIDComponent { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVAR_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.RealEstatePropertyIDComponent, 0, 10);
		return validator.Results;
	}
}
