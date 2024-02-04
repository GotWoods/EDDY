using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._353;

public class LM15 {
	[SectionPosition(1)] public M15_CustomsEventsAdvisoryDetails CustomsEventsAdvisoryDetails { get; set; } = new();
	[SectionPosition(2)] public V1_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(3)] public V2_VesselInformation? VesselInformation { get; set; }
	[SectionPosition(4)] public MEA_Measurements? Measurements { get; set; }
	[SectionPosition(5)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LM15>(this);
		validator.Required(x => x.CustomsEventsAdvisoryDetails);
		validator.CollectionSize(x => x.Remarks, 0, 4);
		return validator.Results;
	}
}
