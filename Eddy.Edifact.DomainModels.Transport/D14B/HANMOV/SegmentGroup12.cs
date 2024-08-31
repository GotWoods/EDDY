using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D14B;

namespace Eddy.Edifact.DomainModels.Transport.D14B.HANMOV;

public class SegmentGroup12 {
	[SectionPosition(1)] public LIN_LineItem LineItem { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup12_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup12>(this);
		validator.Required(x => x.LineItem);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
