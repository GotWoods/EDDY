using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3070._868;

public class LE20 {
	[SectionPosition(1)] public E20_SegmentHeaderInformation SegmentHeaderInformation { get; set; } = new();
	[SectionPosition(2)] public List<E22_DataElementRelationshipsInASegment> DataElementRelationshipsInASegment { get; set; } = new();
	[SectionPosition(3)] public List<LE20_LE24> LE24 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE20>(this);
		validator.Required(x => x.SegmentHeaderInformation);
		validator.CollectionSize(x => x.DataElementRelationshipsInASegment, 0, 100);
		validator.CollectionSize(x => x.LE24, 0, 100);
		foreach (var item in LE24) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
