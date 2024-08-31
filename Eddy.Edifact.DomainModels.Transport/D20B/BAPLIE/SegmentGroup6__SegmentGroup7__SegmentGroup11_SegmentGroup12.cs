using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20B;

namespace Eddy.Edifact.DomainModels.Transport.D20B.BAPLIE;

public class SegmentGroup6__SegmentGroup7__SegmentGroup11_SegmentGroup12 {
	[SectionPosition(1)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(2)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6__SegmentGroup7__SegmentGroup11_SegmentGroup12>(this);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		return validator.Results;
	}
}
