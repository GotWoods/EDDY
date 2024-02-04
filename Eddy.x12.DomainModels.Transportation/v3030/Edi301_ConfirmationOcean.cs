using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._301;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi301_ConfirmationOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B1_BeginningSegmentForBookingOrPickUpDelivery BeginningSegmentForBookingOrPickUpDelivery { get; set; } = new();
	[SectionPosition(3)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(4)] public Y3_SpaceConfirmation SpaceConfirmation { get; set; } = new();
	[SectionPosition(5)] public List<Y4_ContainerRelease> ContainerRelease { get; set; } = new();
	[SectionPosition(6)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(7)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(8)] public List<G61_Contact> Contact { get; set; } = new();
	[SectionPosition(9)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(10)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(11)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();

	//Details
	[SectionPosition(12)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(13)] public List<V1_VesselIdentification> VesselIdentification { get; set; } = new();
	[SectionPosition(14)] public List<V9_EventDetail> EventDetail { get; set; } = new();

	//Summary
	[SectionPosition(15)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi301_ConfirmationOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForBookingOrPickUpDelivery);
		validator.CollectionSize(x => x.Authentication, 0, 2);
		validator.Required(x => x.SpaceConfirmation);
		validator.CollectionSize(x => x.ContainerRelease, 0, 10);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 100);
		validator.CollectionSize(x => x.Contact, 0, 3);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		

		validator.CollectionSize(x => x.LN1, 0, 4);
		validator.CollectionSize(x => x.LR4, 1, 20);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		validator.CollectionSize(x => x.VesselIdentification, 0, 2);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		

		validator.CollectionSize(x => x.LLX, 1, 999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
