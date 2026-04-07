using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._194;

public class LHL__LPPL__LPL_LPD {
	[SectionPosition(1)] public PD_PricingData PricingData { get; set; } = new();
	[SectionPosition(2)] public SPI_SpecificationIdentifier? SpecificationIdentifier { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<PDD_PricingDataDetail> PricingDataDetail { get; set; } = new();
	[SectionPosition(5)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(6)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LPPL__LPL_LPD>(this);
		validator.Required(x => x.PricingData);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PricingDataDetail, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		return validator.Results;
	}
}
