using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.APERAK;

public class SegmentGroup3_SegmentGroup4 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3_SegmentGroup4>(this);
		validator.Required(x => x.Reference);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
