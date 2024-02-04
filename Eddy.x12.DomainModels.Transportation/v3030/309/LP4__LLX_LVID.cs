using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._309;

public class LP4__LLX_LVID {
	[SectionPosition(1)] public VID_VehicleID VehicleID { get; set; } = new();
	[SectionPosition(2)] public List<N10_QuantityAndDescription> QuantityAndDescription { get; set; } = new();
	[SectionPosition(3)] public List<H1_HazardousMaterial> HazardousMaterial { get; set; } = new();
	[SectionPosition(4)] public List<H2_AdditionalHazardousMaterialDescription> AdditionalHazardousMaterialDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LVID>(this);
		validator.Required(x => x.VehicleID);
		validator.CollectionSize(x => x.QuantityAndDescription, 0, 999);
		validator.CollectionSize(x => x.HazardousMaterial, 0, 999);
		validator.CollectionSize(x => x.AdditionalHazardousMaterialDescription, 0, 999);
		return validator.Results;
	}
}
