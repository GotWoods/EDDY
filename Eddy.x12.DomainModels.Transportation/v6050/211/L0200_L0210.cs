using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._211;

public class L0200_L0210 {
	[SectionPosition(1)] public AT2_BillOfLadingLineItemDetail BillOfLadingLineItemDetail { get; set; } = new();
	[SectionPosition(2)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(3)] public List<OID_OrderInformationDetail> OrderInformationDetail { get; set; } = new();
	[SectionPosition(4)] public L4_Measurement? Measurement { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0210>(this);
		validator.Required(x => x.BillOfLadingLineItemDetail);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 999999);
		validator.CollectionSize(x => x.OrderInformationDetail, 0, 999999);
		return validator.Results;
	}
}
