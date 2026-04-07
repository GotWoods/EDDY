using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._833;

public class LCRO__LLX_LNX1 {
	[SectionPosition(1)] public NX1_RealEstatePropertyIdentification RealEstatePropertyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_RealEstatePropertyIDComponent> RealEstatePropertyIDComponent { get; set; } = new();
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public ARS_ApplicantResidenceSpecifics? ApplicantResidenceSpecifics { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX_LNX1>(this);
		validator.Required(x => x.RealEstatePropertyIdentification);
		validator.CollectionSize(x => x.RealEstatePropertyIDComponent, 1, 30);
		validator.Required(x => x.DateOrTimeOrPeriod);
		return validator.Results;
	}
}
