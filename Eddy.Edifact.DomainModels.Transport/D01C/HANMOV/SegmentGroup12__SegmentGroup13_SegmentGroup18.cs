using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.HANMOV;

public class SegmentGroup12__SegmentGroup13_SegmentGroup18 {
	[SectionPosition(1)] public PAC_Package Package { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup12__SegmentGroup13__SegmentGroup18_SegmentGroup19> SegmentGroup19 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup12__SegmentGroup13_SegmentGroup18>(this);
		validator.Required(x => x.Package);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup19, 0, 9);
		foreach (var item in SegmentGroup19) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
