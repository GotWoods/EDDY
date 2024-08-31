using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A;

namespace Eddy.Edifact.DomainModels.Transport.D98A.IFTDGN;

public class SegmentGroup6__SegmentGroup8_SegmentGroup9 {
	[SectionPosition(1)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(2)] public COM_CommunicationContact CommunicationContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6__SegmentGroup8_SegmentGroup9>(this);
		validator.Required(x => x.ContactInformation);
		validator.Required(x => x.CommunicationContact);
		return validator.Results;
	}
}
