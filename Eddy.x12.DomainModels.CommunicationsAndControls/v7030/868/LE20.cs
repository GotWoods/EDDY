using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v7030._868;

public class LE20 {
	[SectionPosition(1)] public E20_SegmentHeaderInformation SegmentHeaderInformation { get; set; } = new();
	[SectionPosition(2)] public List<E22_DataElementRelationshipsInASegmentOrComposite> DataElementRelationshipsInASegmentOrComposite { get; set; } = new();
	[SectionPosition(3)] public List<E24_DataElementSequenceInASegmentOrComposite> DataElementSequenceInASegmentOrComposite { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE20>(this);
		validator.Required(x => x.SegmentHeaderInformation);
		validator.CollectionSize(x => x.DataElementRelationshipsInASegmentOrComposite, 0, 100);
		validator.CollectionSize(x => x.DataElementSequenceInASegmentOrComposite, 0, 100);
		return validator.Results;
	}
}
