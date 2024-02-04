using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;
using Eddy.x12.DomainModels.Transportation.v8020._127;

namespace Eddy.x12.DomainModels.Transportation.v8020;

public class Edi127_VehicleBayingOrder {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BVB_BeginningSegmentForVehicleBayingOrder BeginningSegmentForVehicleBayingOrder { get; set; } = new();
	[SectionPosition(3)] public G62_DateTime DateTime { get; set; } = new();
	[SectionPosition(4)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(5)] public List<SFC_StorageFacilityCharacteristics> StorageFacilityCharacteristics { get; set; } = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi127_VehicleBayingOrder>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForVehicleBayingOrder);
		validator.Required(x => x.DateTime);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 99);
		validator.CollectionSize(x => x.StorageFacilityCharacteristics, 0, 20);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
