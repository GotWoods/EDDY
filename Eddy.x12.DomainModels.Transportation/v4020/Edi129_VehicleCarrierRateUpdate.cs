using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;
using Eddy.x12.DomainModels.Transportation.v4020._129;

namespace Eddy.x12.DomainModels.Transportation.v4020;

public class Edi129_VehicleCarrierRateUpdate {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public VR_RateOrigin RateOrigin { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public List<LRT> LRT {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi129_VehicleCarrierRateUpdate>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.RateOrigin);
		validator.CollectionSize(x => x.DateTime, 1, 3);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LRT, 1, 99);
		foreach (var item in LRT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
