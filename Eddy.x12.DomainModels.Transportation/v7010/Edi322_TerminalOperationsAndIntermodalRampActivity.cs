using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;
using Eddy.x12.DomainModels.Transportation.v7010._322;

namespace Eddy.x12.DomainModels.Transportation.v7010;

public class Edi322_TerminalOperationsAndIntermodalRampActivity {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ZC1_BeginningSegmentForDataCorrectionOrChange? BeginningSegmentForDataCorrectionOrChange { get; set; }
	[SectionPosition(3)] public Q5_StatusDetails StatusDetails { get; set; } = new();
	[SectionPosition(4)] public List<LN7> LN7 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi322_TerminalOperationsAndIntermodalRampActivity>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.StatusDetails);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN7, 1, 1000);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
