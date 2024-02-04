using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;
using Eddy.x12.DomainModels.Transportation.v4010._161;

namespace Eddy.x12.DomainModels.Transportation.v4010;

public class Edi161_TrainSheet {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTS_BeginningSegmentForTrainSheets BeginningSegmentForTrainSheets { get; set; } = new();
	[SectionPosition(3)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(4)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(6)] public List<LFAC> LFAC {get;set;} = new();
	[SectionPosition(7)] public List<LNM1> LNM1 {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer? TransactionSetTrailer { get; set; }

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi161_TrainSheet>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTrainSheets);
		validator.CollectionSize(x => x.EventDetail, 0, 100);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 3);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 5);
		

		validator.CollectionSize(x => x.LFAC, 1, 10);
		validator.CollectionSize(x => x.LNM1, 0, 10);
		foreach (var item in LFAC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
