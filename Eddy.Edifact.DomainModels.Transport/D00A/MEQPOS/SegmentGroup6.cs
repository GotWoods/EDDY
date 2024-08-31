using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A;

namespace Eddy.Edifact.DomainModels.Transport.D00A.MEQPOS;

public class SegmentGroup6 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		return validator.Results;
	}
}
