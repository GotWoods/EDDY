using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v4030._997;

public class LAK2_LAK3 {
	[SectionPosition(1)] public AK3_DataSegmentNote DataSegmentNote { get; set; } = new();
	[SectionPosition(2)] public List<AK4_DataElementNote> DataElementNote { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAK2_LAK3>(this);
		validator.Required(x => x.DataSegmentNote);
		validator.CollectionSize(x => x.DataElementNote, 0, 99);
		return validator.Results;
	}
}
