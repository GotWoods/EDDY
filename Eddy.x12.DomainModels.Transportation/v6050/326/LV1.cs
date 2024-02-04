using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._326;

public class LV1 {
	[SectionPosition(1)] public V1_VesselIdentification VesselIdentification { get; set; } = new();
	[SectionPosition(2)] public MBL_BillOfLading? BillOfLading { get; set; }
	[SectionPosition(3)] public G1_ShipmentTypeInformation? ShipmentTypeInformation { get; set; }
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(6)] public List<LV1_LN7> LN7 {get;set;} = new();
	[SectionPosition(7)] public List<LV1_LR4> LR4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LV1>(this);
		validator.Required(x => x.VesselIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 999);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 9999);
		validator.CollectionSize(x => x.LN7, 0, 999);
		validator.CollectionSize(x => x.LR4, 1, 4);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
