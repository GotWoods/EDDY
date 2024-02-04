using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;
using Eddy.x12.DomainModels.Transportation.v7020._475;

namespace Eddy.x12.DomainModels.Transportation.v7020;

public class Edi475_RailRouteFileMaintenance {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<LR9> LR9 {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi475_RailRouteFileMaintenance>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LR9, 1, 50);
		foreach (var item in LR9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
