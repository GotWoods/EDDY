using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._421;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi421_EstimatedTimeOfArrivalAndCarScheduling {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<LIS2> LIS2 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi421_EstimatedTimeOfArrivalAndCarScheduling>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LIS2, 1, 20);
		foreach (var item in LIS2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
