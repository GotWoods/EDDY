using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13B;

namespace Eddy.Edifact.DomainModels.Transport.D13B.IFCSUM;

public class SegmentGroup27_SegmentGroup33 {
	[SectionPosition(1)] public TOD_TermsOfDeliveryOrTransport TermsOfDeliveryOrTransport { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27_SegmentGroup33>(this);
		validator.Required(x => x.TermsOfDeliveryOrTransport);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		return validator.Results;
	}
}
