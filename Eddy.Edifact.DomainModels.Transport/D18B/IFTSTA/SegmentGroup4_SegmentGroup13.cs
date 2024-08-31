using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18B;

namespace Eddy.Edifact.DomainModels.Transport.D18B.IFTSTA;

public class SegmentGroup4_SegmentGroup13 {
	[SectionPosition(1)] public DAM_Damage Damage { get; set; } = new();
	[SectionPosition(2)] public List<COD_ComponentDetails> ComponentDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4_SegmentGroup13>(this);
		validator.Required(x => x.Damage);
		validator.CollectionSize(x => x.ComponentDetails, 1, 9);
		return validator.Results;
	}
}
