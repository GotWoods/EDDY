using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;
using Eddy.x12.DomainModels.Transportation.v4060._216;

namespace Eddy.x12.DomainModels.Transportation.v4060;

public class Edi216_MotorCarrierShipmentPickupNotification {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public PUN_BeginningSegmentForMotorCarrierPickUpNotification BeginningSegmentForMotorCarrierPickupNotification { get; set; } = new();
	[SectionPosition(3)] public G61_Contact? Contact { get; set; }
	[SectionPosition(4)] public TEM_PickUpTotals? PickupTotals { get; set; }
	[SectionPosition(5)] public List<PRF_PurchaseOrderReference> PurchaseOrderReference { get; set; } = new();
	[SectionPosition(6)] public K2_AdministrativeMessage? AdministrativeMessage { get; set; }
	[SectionPosition(7)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi216_MotorCarrierShipmentPickupNotification>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForMotorCarrierPickupNotification);
		validator.CollectionSize(x => x.PurchaseOrderReference, 1, 2147483647);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 1, 2);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
