using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.IFCSUM;

public class SegmentGroup26__SegmentGroup51__SegmentGroup66_SegmentGroup67 {
	[SectionPosition(1)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(2)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51__SegmentGroup66_SegmentGroup67>(this);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		return validator.Results;
	}
}
