using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;
using Eddy.x12.DomainModels.Transportation.v7020._303;

namespace Eddy.x12.DomainModels.Transportation.v7020;

public class Edi303_BookingCancellationOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B1_BeginningSegmentForBookingOrPickupDelivery BeginningSegmentForBookingOrPickupDelivery { get; set; } = new();
	[SectionPosition(3)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(4)] public Y5_SpaceBookingCancellation SpaceBookingCancellation { get; set; } = new();
	[SectionPosition(5)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi303_BookingCancellationOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForBookingOrPickupDelivery);
		validator.CollectionSize(x => x.Authentication, 0, 2);
		validator.Required(x => x.SpaceBookingCancellation);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
