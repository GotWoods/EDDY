using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._412;

public class LR12_LR13 {
	[SectionPosition(1)] public R13_LineItemRepair LineItemRepair { get; set; } = new();
	[SectionPosition(2)] public List<IT1_BaselineItemDataInvoice> BaselineItemDataInvoice { get; set; } = new();
	[SectionPosition(3)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LR12_LR13>(this);
		validator.Required(x => x.LineItemRepair);
		validator.CollectionSize(x => x.BaselineItemDataInvoice, 0, 10);
		validator.CollectionSize(x => x.Information, 0, 10);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 10);
		return validator.Results;
	}
}
