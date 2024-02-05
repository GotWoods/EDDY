using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3010._868;

public class LE10_LE12 {
	[SectionPosition(1)] public E12_SectionIndicator SectionIndicator { get; set; } = new();
	[SectionPosition(2)] public List<E14_SegmentOrderInTransactionSet> SegmentOrderInTransactionSet { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE10_LE12>(this);
		validator.Required(x => x.SectionIndicator);
		validator.CollectionSize(x => x.SegmentOrderInTransactionSet, 0, 200);
		return validator.Results;
	}
}
