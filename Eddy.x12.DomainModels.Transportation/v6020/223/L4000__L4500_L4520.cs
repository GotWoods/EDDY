using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020._223;

public class L4000__L4500_L4520 {
	[SectionPosition(1)] public OID_OrderInformationDetail OrderInformationDetail { get; set; } = new();
	[SectionPosition(2)] public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L4000__L4500_L4520>(this);
		validator.Required(x => x.OrderInformationDetail);
		validator.CollectionSize(x => x.DestinationQuantity, 0, 10);
		return validator.Results;
	}
}
