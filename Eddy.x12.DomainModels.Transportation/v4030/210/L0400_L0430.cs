using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._210;

public class L0400_L0430 {
	[SectionPosition(1)] public OID_OrderIdentificationDetail OrderIdentificationDetail { get; set; } = new();
	[SectionPosition(2)] public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400_L0430>(this);
		validator.Required(x => x.OrderIdentificationDetail);
		validator.CollectionSize(x => x.DestinationQuantity, 0, 10);
		return validator.Results;
	}
}
