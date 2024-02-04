using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._304;

public class LLX__LL0_LPO4 {
	[SectionPosition(1)] public PO4_ItemPhysicalDetails ItemPhysicalDetails { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(4)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL0_LPO4>(this);
		validator.Required(x => x.ItemPhysicalDetails);
		validator.CollectionSize(x => x.Measurements, 0, 5);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 5);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 5);
		return validator.Results;
	}
}
