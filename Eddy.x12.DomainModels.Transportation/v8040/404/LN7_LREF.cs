using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._404;

public class LN7_LREF {
	[SectionPosition(1)] public REF_ReferenceInformation ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<N10_QuantityAndDescription> QuantityAndDescription { get; set; } = new();
	[SectionPosition(4)] public SMD_ConsolidatedShipmentManifestData? ConsolidatedShipmentManifestData { get; set; }
	[SectionPosition(5)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(6)] public List<LN7__LREF_LL0> LL0 {get;set;} = new();
	[SectionPosition(7)] public List<LN7__LREF_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7_LREF>(this);
		validator.Required(x => x.ReferenceInformation);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.QuantityAndDescription, 0, 15);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 36);
		validator.CollectionSize(x => x.LL0, 0, 25);
		validator.CollectionSize(x => x.LN1, 0, 15);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
