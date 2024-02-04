using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;
using Eddy.x12.DomainModels.Transportation.v4040._301;

namespace Eddy.x12.DomainModels.Transportation.v4040;

public class Edi301_ConfirmationOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B1_BeginningSegmentForBookingOrPickUpDelivery BeginningSegmentForBookingOrPickUpDelivery { get; set; } = new();
	[SectionPosition(3)] public List<G61_Contact> Contact { get; set; } = new();
	[SectionPosition(4)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(5)] public Y3_SpaceConfirmation SpaceConfirmation { get; set; } = new();
	[SectionPosition(6)] public List<LY4> LY4 {get;set;} = new();
	[SectionPosition(7)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(8)] public List<R2A_RouteInformationWithPreference> RouteInformationWithPreference { get; set; } = new();
	[SectionPosition(9)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(10)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(11)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(12)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(13)] public List<EA_EquipmentAttributes> EquipmentAttributes { get; set; } = new();

	//Details
	[SectionPosition(14)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(15)] public List<V1_VesselIdentification> VesselIdentification { get; set; } = new();
	[SectionPosition(16)] public List<V9_EventDetail> EventDetail { get; set; } = new();

	//Summary
	[SectionPosition(17)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi301_ConfirmationOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForBookingOrPickUpDelivery);
		validator.CollectionSize(x => x.Contact, 0, 3);
		validator.CollectionSize(x => x.Authentication, 0, 2);
		validator.Required(x => x.SpaceConfirmation);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 100);
		validator.CollectionSize(x => x.RouteInformationWithPreference, 0, 25);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.EquipmentAttributes, 0, 5);
		

		validator.CollectionSize(x => x.LY4, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 4);
		validator.CollectionSize(x => x.LR4, 1, 20);
		foreach (var item in LY4) validator.Results.AddRange(item.Validate().Errors);
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
