using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;
using Eddy.x12.DomainModels.Transportation.v6020._323;

namespace Eddy.x12.DomainModels.Transportation.v6020;

public class Edi323_VesselScheduleAndItineraryOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public V1_VesselIdentification VesselIdentification { get; set; } = new();
	[SectionPosition(3)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(4)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi323_VesselScheduleAndItineraryOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.VesselIdentification);
		validator.CollectionSize(x => x.Remarks, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LR4, 1, 999);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
