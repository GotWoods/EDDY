using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._311;

public class LLX_LED {
	[SectionPosition(1)] public ED_EquipmentDescription EquipmentDescription { get; set; } = new();
	[SectionPosition(2)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(3)] public NA_CrossReferenceEquipment? CrossReferenceEquipment { get; set; }
	[SectionPosition(4)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(5)] public G2_BeyondRouting? BeyondRouting { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LED>(this);
		validator.Required(x => x.EquipmentDescription);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		return validator.Results;
	}
}
