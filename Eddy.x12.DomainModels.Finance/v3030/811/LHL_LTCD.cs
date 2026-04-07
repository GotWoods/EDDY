using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._811;

public class LHL_LTCD {
	[SectionPosition(1)] public TCD_ItemizedCallDetail ItemizedCallDetail { get; set; } = new();
	[SectionPosition(2)] public List<SI_ServiceCharacteristicIdentification> ServiceCharacteristicIdentification { get; set; } = new();
	[SectionPosition(3)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LTCD>(this);
		validator.Required(x => x.ItemizedCallDetail);
		validator.CollectionSize(x => x.ServiceCharacteristicIdentification, 0, 2);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		return validator.Results;
	}
}
