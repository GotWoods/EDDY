using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020._350;

public class LP4 {
	[SectionPosition(1)] public P4_PortInformation PortInformation { get; set; } = new();
	[SectionPosition(2)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(3)] public List<VEH_VehicleInformation> VehicleInformation { get; set; } = new();
	[SectionPosition(4)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(5)] public List<LP4_LVID> LVID {get;set;} = new();
	[SectionPosition(6)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(7)] public List<LP4_LX4> LX4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.PortInformation);
		validator.CollectionSize(x => x.EventDetail, 0, 20);
		validator.CollectionSize(x => x.VehicleInformation, 0, 10);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 0, 9999);
		validator.CollectionSize(x => x.Remarks, 0, 4);
		validator.CollectionSize(x => x.LVID, 0, 9999);
		validator.CollectionSize(x => x.LX4, 0, 9999);
		foreach (var item in LVID) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LX4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
