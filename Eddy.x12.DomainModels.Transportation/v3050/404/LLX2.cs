using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._404;

public class LLX2 {
	[SectionPosition(1)] public T1_TransitInboundOrigin TransitInboundOrigin { get; set; } = new();
	[SectionPosition(2)] public List<T2_TransitInboundLading> TransitInboundLading { get; set; } = new();
	[SectionPosition(3)] public List<T3_TransitInboundRoute> TransitInboundRoute { get; set; } = new();
	[SectionPosition(4)] public T6_TransitInboundRates? TransitInboundRates { get; set; }
	[SectionPosition(5)] public List<T8_FreeFormTransitData> FreeFormTransitData { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX2>(this);
		validator.Required(x => x.TransitInboundOrigin);
		validator.CollectionSize(x => x.TransitInboundLading, 0, 30);
		validator.CollectionSize(x => x.TransitInboundRoute, 0, 12);
		validator.CollectionSize(x => x.FreeFormTransitData, 0, 99);
		return validator.Results;
	}
}
