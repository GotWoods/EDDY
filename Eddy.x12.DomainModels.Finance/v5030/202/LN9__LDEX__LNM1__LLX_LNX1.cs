using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._202;

public class LN9__LDEX__LNM1__LLX_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public REA_RealEstatePropertyInformation? RealEstatePropertyInformation { get; set; }
	[SectionPosition(4)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX__LNM1__LLX_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 0, 15);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 0, 2);
		return validator.Results;
	}
}
