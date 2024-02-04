using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._451;

public class LED {
	[SectionPosition(1)] public ED_EquipmentDescription EquipmentDescription { get; set; } = new();
	[SectionPosition(2)] public List<ER_RailEventReporting> RailEventReporting { get; set; } = new();
	[SectionPosition(3)] public NA_CrossReferenceEquipment? CrossReferenceEquipment { get; set; }
	[SectionPosition(4)] public List<IC_IntermodalChassisEquipment> IntermodalChassisEquipment { get; set; } = new();
	[SectionPosition(5)] public List<CLR_CarLocationRoutingRequest> CarLocationRoutingRequest { get; set; } = new();
	[SectionPosition(6)] public ES_EquipmentStatus? EquipmentStatus { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LED>(this);
		validator.Required(x => x.EquipmentDescription);
		validator.CollectionSize(x => x.RailEventReporting, 0, 2);
		validator.CollectionSize(x => x.IntermodalChassisEquipment, 0, 3);
		validator.CollectionSize(x => x.CarLocationRoutingRequest, 0, 10);
		return validator.Results;
	}
}
