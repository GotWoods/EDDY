using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._456;

public class LLX_LER {
	[SectionPosition(1)] public ER_RailEventReporting RailEventReporting { get; set; } = new();
	[SectionPosition(2)] public NA_CrossReferenceEquipment? CrossReferenceEquipment { get; set; }
	[SectionPosition(3)] public List<IC_IntermodalChassisEquipment> IntermodalChassisEquipment { get; set; } = new();
	[SectionPosition(4)] public ES_EquipmentStatus? EquipmentStatus { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LER>(this);
		validator.Required(x => x.RailEventReporting);
		validator.CollectionSize(x => x.IntermodalChassisEquipment, 0, 3);
		return validator.Results;
	}
}
