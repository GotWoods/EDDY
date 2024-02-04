using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;
using Eddy.x12.DomainModels.Transportation.v4010._216;

namespace Eddy.x12.DomainModels.Transportation.v4010;

public class Edi216_MotorCarrierShipmentPickUpNotification {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public PUN_BeginningSegmentForMotorCarrierPickUpNotification BeginningSegmentForMotorCarrierPickUpNotification { get; set; } = new();
	[SectionPosition(3)] public G61_Contact? Contact { get; set; }
	[SectionPosition(4)] public TEM_PickUpTotals? PickUpTotals { get; set; }
	[SectionPosition(5)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi216_MotorCarrierShipmentPickUpNotification>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForMotorCarrierPickUpNotification);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 1, 2);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
