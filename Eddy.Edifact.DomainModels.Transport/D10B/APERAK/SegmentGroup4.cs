using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.APERAK;

public class SegmentGroup4 {
	[SectionPosition(1)] public ERC_ApplicationErrorInformation ApplicationErrorInformation { get; set; } = new();
	[SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup4_SegmentGroup5> SegmentGroup5 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4>(this);
		validator.Required(x => x.ApplicationErrorInformation);
		validator.Required(x => x.FreeText);
		validator.CollectionSize(x => x.SegmentGroup5, 0, 9);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
