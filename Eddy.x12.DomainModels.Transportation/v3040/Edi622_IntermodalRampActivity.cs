using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;
using Eddy.x12.DomainModels.Transportation.v3040._622;

namespace Eddy.x12.DomainModels.Transportation.v3040;

public class Edi622_IntermodalRampActivity {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ZC1_BeginningSegmentForDataCorrectionOrChange? BeginningSegmentForDataCorrectionOrChange { get; set; }
	[SectionPosition(3)] public Q5_StatusDetails? StatusDetails { get; set; }
	[SectionPosition(4)] public List<LW2A> LW2A {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi622_IntermodalRampActivity>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LW2A, 1, 1000);
		foreach (var item in LW2A) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
