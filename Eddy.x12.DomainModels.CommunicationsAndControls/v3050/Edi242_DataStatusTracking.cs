using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;
using Eddy.x12.DomainModels.CommunicationsAndControls.v3050._242;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3050;

public class Edi242_DataStatusTracking {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<LIIS> LIIS {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi242_DataStatusTracking>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LIIS, 1, 2147483647);
		foreach (var item in LIIS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
