using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;
using Eddy.x12.DomainModels.Transportation.v8030._125;

namespace Eddy.x12.DomainModels.Transportation.v8030;

public class Edi125_MultilevelRailcarLoadDetails {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction BeginningSegmentForMultilevelRailcarLoadDetailsTransaction { get; set; } = new();
	[SectionPosition(3)] public G62_DateTime DateTime { get; set; } = new();
	[SectionPosition(4)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(5)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi125_MultilevelRailcarLoadDetails>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForMultilevelRailcarLoadDetailsTransaction);
		validator.Required(x => x.DateTime);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 21);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
