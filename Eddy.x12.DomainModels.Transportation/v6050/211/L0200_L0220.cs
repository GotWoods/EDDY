using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._211;

public class L0200_L0220 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(3)] public List<OID_OrderInformationDetail> OrderInformationDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0220>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 999999);
		validator.CollectionSize(x => x.OrderInformationDetail, 0, 999999);
		return validator.Results;
	}
}
