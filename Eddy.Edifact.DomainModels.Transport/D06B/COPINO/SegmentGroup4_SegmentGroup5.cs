using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06B;

namespace Eddy.Edifact.DomainModels.Transport.D06B.COPINO;

public class SegmentGroup4_SegmentGroup5 {
	[SectionPosition(1)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(2)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4_SegmentGroup5>(this);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		return validator.Results;
	}
}
