using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._155;

public class L20000__L22000_L22100 {
	[SectionPosition(1)] public REQ_RequestInformation RequestInformation { get; set; } = new();
	[SectionPosition(2)] public LOD_LocationDescription? LocationDescription { get; set; }
	[SectionPosition(3)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(4)] public List<FDA_FacilityDescription> FacilityDescription { get; set; } = new();
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<AWD_AmountWithDescription> AmountWithDescription { get; set; } = new();
	[SectionPosition(7)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(8)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(9)] public N1_Name? Name { get; set; }
	[SectionPosition(10)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L22000_L22100>(this);
		validator.Required(x => x.RequestInformation);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.FacilityDescription, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.AmountWithDescription, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		return validator.Results;
	}
}
