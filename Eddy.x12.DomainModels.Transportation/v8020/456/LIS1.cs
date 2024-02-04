using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._456;

public class LIS1 {
	[SectionPosition(1)] public IS1_EstimatedTimeOfArrivalAndCarScheduling EstimatedTimeOfArrivalAndCarScheduling { get; set; } = new();
	[SectionPosition(2)] public List<ISC_InterlineServiceCommitmentDetail> InterlineServiceCommitmentDetail { get; set; } = new();
	[SectionPosition(3)] public List<IS2_ScheduledEvents> ScheduledEvents { get; set; } = new();
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIS1>(this);
		validator.Required(x => x.EstimatedTimeOfArrivalAndCarScheduling);
		validator.CollectionSize(x => x.InterlineServiceCommitmentDetail, 0, 99);
		validator.CollectionSize(x => x.ScheduledEvents, 1, 99);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 5);
		return validator.Results;
	}
}
