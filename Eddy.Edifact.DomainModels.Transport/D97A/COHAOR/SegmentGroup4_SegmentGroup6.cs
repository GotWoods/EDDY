using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A;

namespace Eddy.Edifact.DomainModels.Transport.D97A.COHAOR;

public class SegmentGroup4_SegmentGroup6 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<CTA_ContactInformation> ContactInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4_SegmentGroup6>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.ContactInformation, 1, 9);
		return validator.Results;
	}
}
