using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v4030._868;

public class LE41 {
	[SectionPosition(1)] public E41_CompositeHeaderInformation CompositeHeaderInformation { get; set; } = new();
	[SectionPosition(2)] public List<E22_DataElementRelationshipsInASegmentOrComposite> DataElementRelationshipsInASegmentOrComposite { get; set; } = new();
	[SectionPosition(3)] public List<E24_DataElementSequenceInASegmentOrComposite> DataElementSequenceInASegmentOrComposite { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE41>(this);
		validator.Required(x => x.CompositeHeaderInformation);
		validator.CollectionSize(x => x.DataElementRelationshipsInASegmentOrComposite, 0, 100);
		validator.CollectionSize(x => x.DataElementSequenceInASegmentOrComposite, 0, 100);
		return validator.Results;
	}
}
