using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D02A;

namespace Eddy.Edifact.DomainModels.Transport.D02A.IFTMBP;

public class SegmentGroup14_SegmentGroup20 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup14__SegmentGroup20_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup14_SegmentGroup20>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 9);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
