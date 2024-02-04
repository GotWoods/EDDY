using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._602;

public class L0300__L0310_L0312 {
	[SectionPosition(1)] public RH_PersonalPropertyRate PersonalPropertyRate { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300__L0310_L0312>(this);
		validator.Required(x => x.PersonalPropertyRate);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 30);
		return validator.Results;
	}
}
