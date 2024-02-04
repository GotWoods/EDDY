using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._456;

public class LER {
	[SectionPosition(1)] public ER_RailEventReporting RailEventReporting { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(3)] public NA_CrossReferenceEquipment? CrossReferenceEquipment { get; set; }
	[SectionPosition(4)] public ES_EquipmentStatus? EquipmentStatus { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LER>(this);
		validator.Required(x => x.RailEventReporting);
		return validator.Results;
	}
}
