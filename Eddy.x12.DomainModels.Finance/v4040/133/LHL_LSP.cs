using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._133;

public class LHL_LSP {
	[SectionPosition(1)] public SP_SpecialProgram SpecialProgram { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LSP>(this);
		validator.Required(x => x.SpecialProgram);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 1, 2147483647);
		return validator.Results;
	}
}
