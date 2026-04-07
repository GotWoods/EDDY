using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._810;

public class LIT1_LV1 {
	[SectionPosition(1)] public V1_VesselIdentification VesselIdentification { get; set; } = new();
	[SectionPosition(2)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIT1_LV1>(this);
		validator.Required(x => x.VesselIdentification);
		validator.CollectionSize(x => x.PortOrTerminal, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		return validator.Results;
	}
}
