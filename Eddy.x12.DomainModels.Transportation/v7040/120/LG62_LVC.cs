using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._120;

public class LG62_LVC {
	[SectionPosition(1)] public VC_MotorVehicleControl MotorVehicleControl { get; set; } = new();
	[SectionPosition(2)] public VC1_VehicleDetail? VehicleDetail { get; set; }
	[SectionPosition(3)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(4)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(5)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(6)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(7)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(8)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LG62_LVC>(this);
		validator.Required(x => x.MotorVehicleControl);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		return validator.Results;
	}
}
