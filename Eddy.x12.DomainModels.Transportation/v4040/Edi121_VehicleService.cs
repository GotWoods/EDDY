using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;
using Eddy.x12.DomainModels.Transportation.v4040._121;

namespace Eddy.x12.DomainModels.Transportation.v4040;

public class Edi121_VehicleService {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BVS_BeginningSegmentForVehicleService BeginningSegmentForVehicleService { get; set; } = new();
	[SectionPosition(3)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(4)] public V1_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(5)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(6)] public List<LVC> LVC {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi121_VehicleService>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForVehicleService);
		validator.CollectionSize(x => x.DateTime, 0, 3);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LVC, 1, 9999);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
