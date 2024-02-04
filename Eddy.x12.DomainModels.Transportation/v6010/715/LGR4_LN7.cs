using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Transportation.v6010._715;

public class LGR4_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<GR5_LoadingDetails> LoadingDetails { get; set; } = new();
	[SectionPosition(3)] public V1_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LGR4_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.LoadingDetails, 0, 10);
		validator.CollectionSize(x => x.PortOrTerminal, 0, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		return validator.Results;
	}
}
