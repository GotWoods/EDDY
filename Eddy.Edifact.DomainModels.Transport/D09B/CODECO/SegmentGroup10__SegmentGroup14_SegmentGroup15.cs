using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09B;

namespace Eddy.Edifact.DomainModels.Transport.D09B.CODECO;

public class SegmentGroup10__SegmentGroup14_SegmentGroup15 {
	[SectionPosition(1)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(2)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup10__SegmentGroup14_SegmentGroup15>(this);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		return validator.Results;
	}
}
