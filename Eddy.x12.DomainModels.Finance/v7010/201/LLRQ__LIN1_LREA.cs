using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._201;

public class LLRQ__LIN1_LREA {
	[SectionPosition(1)] public REA_RealEstatePropertyInformation RealEstatePropertyInformation { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(4)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ__LIN1_LREA>(this);
		validator.Required(x => x.RealEstatePropertyInformation);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 6);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 30);
		return validator.Results;
	}
}
