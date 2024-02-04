using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;
using Eddy.x12.DomainModels.Transportation.v4020._433;

namespace Eddy.x12.DomainModels.Transportation.v4020;

public class Edi433_RailroadReciprocalSwitchFile {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public SMS_StationCodesSegment StationCodesSegment { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi433_RailroadReciprocalSwitchFile>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		validator.Required(x => x.StationCodesSegment);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
