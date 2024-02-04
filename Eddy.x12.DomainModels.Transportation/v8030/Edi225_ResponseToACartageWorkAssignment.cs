using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;
using Eddy.x12.DomainModels.Transportation.v8030._225;

namespace Eddy.x12.DomainModels.Transportation.v8030;

public class Edi225_ResponseToACartageWorkAssignment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public SCP_BeginningSegmentForACartageWorkAssignmentResponse BeginningSegmentForACartageWorkAssignmentResponse { get; set; } = new();
	[SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi225_ResponseToACartageWorkAssignment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForACartageWorkAssignmentResponse);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
