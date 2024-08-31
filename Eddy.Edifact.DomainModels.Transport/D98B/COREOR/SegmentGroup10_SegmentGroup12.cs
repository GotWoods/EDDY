using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B;

namespace Eddy.Edifact.DomainModels.Transport.D98B.COREOR;

public class SegmentGroup10_SegmentGroup12 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(4)] public COM_CommunicationContact CommunicationContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup10_SegmentGroup12>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		validator.Required(x => x.ContactInformation);
		validator.Required(x => x.CommunicationContact);
		return validator.Results;
	}
}
