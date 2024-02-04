using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;
using Eddy.x12.DomainModels.Transportation.v7050._990;

namespace Eddy.x12.DomainModels.Transportation.v7050;

public class Edi990_ResponseToALoadTender {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B1_BeginningSegmentForBookingOrPickupDelivery BeginningSegmentForBookingOrPickupDelivery { get; set; } = new();
	[SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi990_ResponseToALoadTender>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForBookingOrPickupDelivery);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
