using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._300;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(3)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(4)] public L0_LineItemQuantityAndWeight? LineItemQuantityAndWeight { get; set; }
	[SectionPosition(5)] public L5_DescriptionMarksAndNumbers? DescriptionMarksAndNumbers { get; set; }
	[SectionPosition(6)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(7)] public List<LLX_LH1> LH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.LH1, 0, 10);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
