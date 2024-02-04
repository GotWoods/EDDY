using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._603;

public class LN21 {
	[SectionPosition(1)] public N21_EquipmentRegistrationDetails EquipmentRegistrationDetails { get; set; } = new();
	[SectionPosition(2)] public VEH_VehicleInformation? VehicleInformation { get; set; }
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<LQ_IndustryCodeIdentification> IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(7)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN21>(this);
		validator.Required(x => x.EquipmentRegistrationDetails);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.Measurements, 0, 20);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 20);
		validator.CollectionSize(x => x.IndustryCodeIdentification, 0, 20);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		return validator.Results;
	}
}
