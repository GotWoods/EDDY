using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13B;

namespace Eddy.Edifact.DomainModels.Transport.D13B.COPARN;

public class SegmentGroup13_SegmentGroup20 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(4)] public COM_CommunicationContact CommunicationContact { get; set; } = new();
	[SectionPosition(5)] public List<RFF_Reference> Reference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13_SegmentGroup20>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		validator.Required(x => x.ContactInformation);
		validator.Required(x => x.CommunicationContact);
		validator.CollectionSize(x => x.Reference, 1, 9);
		return validator.Results;
	}
}
