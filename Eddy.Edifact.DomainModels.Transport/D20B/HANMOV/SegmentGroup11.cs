using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20B;

namespace Eddy.Edifact.DomainModels.Transport.D20B.HANMOV;

public class SegmentGroup11 {
	[SectionPosition(1)] public TOD_TermsOfDeliveryOrTransport TermsOfDeliveryOrTransport { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup11>(this);
		validator.Required(x => x.TermsOfDeliveryOrTransport);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		return validator.Results;
	}
}
