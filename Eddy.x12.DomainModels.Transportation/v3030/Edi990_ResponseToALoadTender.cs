using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._990;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi990_ResponseToALoadTender {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B1_BeginningSegmentForBookingOrPickUpDelivery BeginningSegmentForBookingOrPickUpDelivery { get; set; } = new();
	[SectionPosition(3)] public N9_ReferenceNumber? ReferenceNumber { get; set; }
	[SectionPosition(4)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(5)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(6)] public List<L9_ChargeDetail> ChargeDetail { get; set; } = new();
	[SectionPosition(7)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(8)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(9)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi990_ResponseToALoadTender>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForBookingOrPickUpDelivery);
		validator.CollectionSize(x => x.DateTime, 0, 6);
		validator.CollectionSize(x => x.ChargeDetail, 0, 40);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 0, 999);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
