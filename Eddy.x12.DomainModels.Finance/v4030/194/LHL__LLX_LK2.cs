using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._194;

public class LHL__LLX_LK2 {
	[SectionPosition(1)] public K2_AdministrativeMessage AdministrativeMessage { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LLX_LK2>(this);
		validator.Required(x => x.AdministrativeMessage);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 1, 2147483647);
		return validator.Results;
	}
}
