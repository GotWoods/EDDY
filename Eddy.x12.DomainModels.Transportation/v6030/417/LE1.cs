using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._417;

public class LE1 {
	[SectionPosition(1)] public E1_EmptyCarDispositionPendedDestinationConsignee EmptyCarDispositionPendedDestinationConsignee { get; set; } = new();
	[SectionPosition(2)] public E4_EmptyCarDispositionPendedDestinationCity EmptyCarDispositionPendedDestinationCity { get; set; } = new();
	[SectionPosition(3)] public List<E5_EmptyCarDispositionPendedDestinationRoute> EmptyCarDispositionPendedDestinationRoute { get; set; } = new();
	[SectionPosition(4)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE1>(this);
		validator.Required(x => x.EmptyCarDispositionPendedDestinationConsignee);
		validator.Required(x => x.EmptyCarDispositionPendedDestinationCity);
		validator.CollectionSize(x => x.EmptyCarDispositionPendedDestinationRoute, 1, 13);
		return validator.Results;
	}
}
