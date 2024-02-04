using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._858;

public class LHL_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		return validator.Results;
	}
}
