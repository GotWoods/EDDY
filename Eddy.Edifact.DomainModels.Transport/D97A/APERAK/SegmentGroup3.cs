using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A;

namespace Eddy.Edifact.DomainModels.Transport.D97A.APERAK;

public class SegmentGroup3 {
	[SectionPosition(1)] public ERC_ApplicationErrorInformation ApplicationErrorInformation { get; set; } = new();
	[SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup3_SegmentGroup4> SegmentGroup4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3>(this);
		validator.Required(x => x.ApplicationErrorInformation);
		validator.Required(x => x.FreeText);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
