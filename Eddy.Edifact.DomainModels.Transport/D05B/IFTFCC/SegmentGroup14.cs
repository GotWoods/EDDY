using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.IFTFCC;

public class SegmentGroup14 {
	[SectionPosition(1)] public TOD_TermsOfDeliveryOrTransport TermsOfDeliveryOrTransport { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup14>(this);
		validator.Required(x => x.TermsOfDeliveryOrTransport);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 2);
		return validator.Results;
	}
}
