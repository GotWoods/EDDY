using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;
using Eddy.x12.DomainModels.Transportation.v7050._324;

namespace Eddy.x12.DomainModels.Transportation.v7050;

public class Edi324_VesselStowPlanOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public V1_VesselIdentification VesselIdentification { get; set; } = new();
	[SectionPosition(3)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(4)] public List<LN7> LN7 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi324_VesselStowPlanOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.VesselIdentification);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LR4, 1, 20);
		validator.CollectionSize(x => x.LN7, 1, 9999);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
