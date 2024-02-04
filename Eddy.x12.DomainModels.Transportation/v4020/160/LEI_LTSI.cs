using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._160;

public class LEI_LTSI {
	[SectionPosition(1)] public TSI_AutomaticEquipmentTagStatusInformation AutomaticEquipmentTagStatusInformation { get; set; } = new();
	[SectionPosition(2)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(3)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	[SectionPosition(4)] public List<LEI__LTSI_LQTY> LQTY {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LEI_LTSI>(this);
		validator.Required(x => x.AutomaticEquipmentTagStatusInformation);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 25);
		validator.CollectionSize(x => x.IndustryCode, 0, 25);
		validator.CollectionSize(x => x.LQTY, 0, 20);
		foreach (var item in LQTY) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
