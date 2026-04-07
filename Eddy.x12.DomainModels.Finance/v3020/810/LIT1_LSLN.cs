using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._810;

public class LIT1_LSLN {
	[SectionPosition(1)] public SLN_SublineItemDetail SublineItemDetail { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(4)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(5)] public List<TC2_Commodity> Commodity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIT1_LSLN>(this);
		validator.Required(x => x.SublineItemDetail);
		validator.CollectionSize(x => x.ReferenceNumbers, 1, 2147483647);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 1000);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 10);
		validator.CollectionSize(x => x.Commodity, 0, 2);
		return validator.Results;
	}
}
