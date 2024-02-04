using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._121;

public class LVC {
	[SectionPosition(1)] public VC_MotorVehicleControl MotorVehicleControl { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public DEL_Delivery? Delivery { get; set; }
	[SectionPosition(4)] public CGS_Charge? Charge { get; set; }
	[SectionPosition(5)] public REF_ReferenceIdentification? ReferenceIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVC>(this);
		validator.Required(x => x.MotorVehicleControl);
		validator.CollectionSize(x => x.DateTimeReference, 0, 3);
		return validator.Results;
	}
}
