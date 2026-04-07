using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._833;

public class LCRO__LLX_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_RealEstatePropertyIDComponent> RealEstatePropertyIDComponent { get; set; } = new();
	[SectionPosition(3)] public ARS_ApplicantResidenceSpecifics ApplicantResidenceSpecifics { get; set; } = new();
	[SectionPosition(4)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(5)] public N10_QuantityAndDescription? QuantityAndDescription { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.RealEstatePropertyIDComponent, 1, 30);
		validator.Required(x => x.ApplicantResidenceSpecifics);
		return validator.Results;
	}
}
