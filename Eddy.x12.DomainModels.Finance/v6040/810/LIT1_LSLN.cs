using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._810;

public class LIT1_LSLN {
	[SectionPosition(1)] public SLN_SublineItemDetail SublineItemDetail { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(5)] public List<SAC_ServicePromotionAllowanceOrChargeInformation> ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(6)] public List<TC2_Commodity> Commodity { get; set; } = new();
	[SectionPosition(7)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIT1_LSLN>(this);
		validator.Required(x => x.SublineItemDetail);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 1000);
		validator.CollectionSize(x => x.ServicePromotionAllowanceOrChargeInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Commodity, 0, 2);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		return validator.Results;
	}
}
