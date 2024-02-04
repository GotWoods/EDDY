using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._126;

public class LBVA {
	[SectionPosition(1)] public BVA_BeginningVehicleAdvice BeginningVehicleAdvice { get; set; } = new();
	[SectionPosition(2)] public V1_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(3)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	[SectionPosition(4)] public List<LBVA_LVAD> LVAD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBVA>(this);
		validator.Required(x => x.BeginningVehicleAdvice);
		validator.CollectionSize(x => x.TariffReference, 0, 5);
		validator.CollectionSize(x => x.LVAD, 1, 99);
		foreach (var item in LVAD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
