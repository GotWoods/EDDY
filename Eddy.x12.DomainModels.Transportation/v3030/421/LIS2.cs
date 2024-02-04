using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._421;

public class LIS2 {
	[SectionPosition(1)] public IS2_ScheduledEvents ScheduledEvents { get; set; } = new();
	[SectionPosition(2)] public N8_WaybillReference? WaybillReference { get; set; }
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(5)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(6)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(7)] public List<S9_StopOffStation> StopOffStation { get; set; } = new();
	[SectionPosition(8)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(9)] public L5_DescriptionMarksAndNumbers? DescriptionMarksAndNumbers { get; set; }
	[SectionPosition(10)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIS2>(this);
		validator.Required(x => x.ScheduledEvents);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 2);
		validator.CollectionSize(x => x.Name, 0, 2);
		validator.CollectionSize(x => x.StopOffStation, 0, 5);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 5);
		return validator.Results;
	}
}
