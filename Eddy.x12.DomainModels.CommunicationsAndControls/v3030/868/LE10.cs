using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3030._868;

public class LE10 {
	[SectionPosition(1)] public E10_TransactionSetGrouping TransactionSetGrouping { get; set; } = new();
	[SectionPosition(2)] public List<E13_SegmentOrderInTransactionSet> SegmentOrderInTransactionSet { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE10>(this);
		validator.Required(x => x.TransactionSetGrouping);
		validator.CollectionSize(x => x.SegmentOrderInTransactionSet, 0, 1000);
		return validator.Results;
	}
}
