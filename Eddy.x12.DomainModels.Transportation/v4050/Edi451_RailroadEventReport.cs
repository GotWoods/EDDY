using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.Transportation.v4050._451;

namespace Eddy.x12.DomainModels.Transportation.v4050;

public class Edi451_RailroadEventReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<ER_RailEventReporting> RailEventReporting { get; set; } = new();
	[SectionPosition(3)] public List<LED> LED {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi451_RailroadEventReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.CollectionSize(x => x.RailEventReporting, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LED, 1, 999);
		foreach (var item in LED) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
