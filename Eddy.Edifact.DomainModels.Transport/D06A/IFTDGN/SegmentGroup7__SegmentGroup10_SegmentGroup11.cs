using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A;

namespace Eddy.Edifact.DomainModels.Transport.D06A.IFTDGN;

public class SegmentGroup7__SegmentGroup10_SegmentGroup11 {
	[SectionPosition(1)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(2)] public COM_CommunicationContact CommunicationContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7__SegmentGroup10_SegmentGroup11>(this);
		validator.Required(x => x.ContactInformation);
		validator.Required(x => x.CommunicationContact);
		return validator.Results;
	}
}
