using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._422;

public class LLX__LF9__LSCR_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public SCR_ShippersCarOrderedRail? ShippersCarOrderedRail { get; set; }
	[SectionPosition(3)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(4)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LF9__LSCR_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 5);
		return validator.Results;
	}
}
