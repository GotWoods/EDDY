using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._262;

public class L2000__L2100_L2140 {
	[SectionPosition(1)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	[SectionPosition(3)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(6)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(7)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(8)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(9)] public List<III_Information> Information { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2100_L2140>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.QuantityInformation, 0, 10);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 7);
		validator.CollectionSize(x => x.MessageText, 0, 3);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		validator.CollectionSize(x => x.Income, 0, 4);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		return validator.Results;
	}
}
