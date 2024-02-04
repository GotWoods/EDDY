using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;
using Eddy.x12.DomainModels.Transportation.v6010._161;

namespace Eddy.x12.DomainModels.Transportation.v6010;

public class Edi161_TrainSheet {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTS_BeginningSegmentForTrainSheets BeginningSegmentForTrainSheets { get; set; } = new();
	[SectionPosition(3)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(6)] public List<FAC_FacingDirection> FacingDirection { get; set; } = new();
	[SectionPosition(7)] public PWK_Paperwork? Paperwork { get; set; }
	[SectionPosition(8)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(9)] public List<LNM1> LNM1 {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi161_TrainSheet>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTrainSheets);
		validator.CollectionSize(x => x.EventDetail, 1, 100);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 3);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 5);
		validator.CollectionSize(x => x.FacingDirection, 0, 10);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LNM1, 0, 10);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
